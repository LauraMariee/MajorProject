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

    public List<float, int> handleValueList = new List<float, int>();

    public void Start()
    {
        assignData();
    }

    public float getXPosition()
    {
        var handlePosition = physicalHandle.GetComponent<Transform>().position.x;
        return handlePosition;
    }

    public float calculateHandleDifference()
    {
        var physicalDifference = startPoint.GetComponent<Transform>().position.x - endPoint.GetComponent<Transform>().position.x;
        float valueDifference = maxSize - minSize;

        var increment = physicalDifference / valueDifference;
        return increment; 
    }

    public void assignData()
    {
        var iteration = calculateHandleDifference();
        var currentValue = minSize;

        for (int i = 0, i < (maxSize - minSize), i++)
        {
            var handleValue = startPoint + iteration;
            saveData(handleValue, currentValue);
        }

    }

    public void saveData(float pos, int value)
    {
        handleValueList.Add(pos, value);
    }

    public void Update()
    {

    }
}
