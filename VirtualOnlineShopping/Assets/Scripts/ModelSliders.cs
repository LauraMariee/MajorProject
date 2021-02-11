using System.Collections;
using System.Collections.Generic;
using UnityEngine;   

public class ModelSliders : MonoBehaviour
{
    public int minSize;
    public int maxSize;

    public GameObject startPoint;
    public GameObject endPoint;

    public GameObject physicalHandle;


    private readonly List<(float physicalPos, int valuePos)> handleValueList = new List<(float physicalPos, int valuePos)>();

    public void Start()
    {
        AssignData();
    }

    public float GetxPosition()
    {
        var handlePosition = physicalHandle.GetComponent<Transform>().position.x;
        return handlePosition;
    }

    private float CalculateHandleDifference()
    {
        var physicalDifference = startPoint.GetComponent<Transform>().position.x - endPoint.GetComponent<Transform>().position.x;
        float valueDifference = maxSize - minSize;

        var increment = physicalDifference / valueDifference;
        return increment; 
    }

    private void AssignData()
    {
        var iteration = CalculateHandleDifference();
        var currentValue = minSize;
        var newHandleValue = startPoint.GetComponent<Transform>().position.x;

        for (var i = 0; i < (maxSize - minSize); i++)
        {
            var handleValue = newHandleValue + iteration;
            SaveData(handleValue, currentValue);

            currentValue++;
            //newHandleValue = startPoint++; 
        }
    }

    private void SaveData(float pos, int value)
    {
        handleValueList.Add((pos, value));
    }
    public void Update()
    {

    }
}
