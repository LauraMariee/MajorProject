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


    public float getXPosition()
    {
        float handlePosition = physicalHandle.GetComponent<Transform>().position.x;
        return handlePosition;
    }

    public int calculateHandleDifference()
    {
        var physicalDifference = startPoint - endPoint;
        var valueDifference = maxSize - minSize;

        var increment = physicalDifference / valueDifference;
        return increment; 
    }
}
