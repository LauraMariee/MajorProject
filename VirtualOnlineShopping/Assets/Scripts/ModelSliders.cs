using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelSliders : MonoBehaviour
{
    public int defaultValue;
    public int currentValue;

    public int minSize;
    public int maxSize;

    public GameObject physicalHandle;

    // Start is called before the first frame update
    void Start()
    {
        currentValue = defaultValue; 
    }

// Update is called once per frame
    void Update()
    {
        updateValue();
        //Get value from the range
    }

    public float getXPosition()
    {
        float handlePosition = physicalHandle.GetComponent<Transform>().position.x;
        return handlePosition;
        
    }

    private void updateValue()
    {
        if(getXPosition() > defaultValue)
        {
            currentValue++;
        }
        else if(getXPosition() < defaultValue)
        {
            currentValue--; 
        }
        else
        {
            Debug.Log("No Change"); 
        }
        
        //x position increase value
        //Increment by 1
    }
}
