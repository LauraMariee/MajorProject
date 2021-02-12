using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using UnityEngine;   

public class ModelSliders : MonoBehaviour
{
    public int minSize;
    public int maxSize;

    private GameObject startPoint;
    private GameObject endPoint;

    public GameObject physicalHandle;
    
    private Dictionary<float, int> handleValueList = new Dictionary<float, int>();

    public void Start()
    {
        startPoint = GameObject.Find("Start");
        endPoint = GameObject.Find("End");
        
        AssignData();
    }

    private float GetHandlePosition()
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

        for (var i = 0; i <= (maxSize - minSize); i++)
        {
            var handleValue = newHandleValue + iteration;
            SaveData(handleValue, currentValue);
            //Debug.Log(currentValue);

            currentValue++;
            newHandleValue = handleValue; 
        }
    }

    private int GetDataForHandlePos()
    {
        //get handle position
        //Search through List until values match
        if (!handleValueList.Any()) return 0;
        var value = handleValueList[GetHandlePosition()];//get value
        return value;

    }

    private void SaveData(float pos, int value)
    {
        handleValueList.Add(pos, value);
    }

    private void DisplayData()
    {
        foreach (var key in handleValueList)
        {
            Debug.Log("Handle pos is " + GetHandlePosition());
            Debug.Log("Value is " + GetDataForHandlePos());
            Debug.Log("Dictionary data is " + key);
        }
    }

    public void Update()
    {
        DisplayData();
       
    }
}
