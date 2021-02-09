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
    void FixedUpdate()
    {
        //Get value from the range
    }

    public float getXPosition()
    {
        float handlePosition = physicalHandle.GetComponent<Transform>().position.x;
        return handlePosition;
        
    }


    private bool checkBounds()
    {
        Debug.Log("checkBounds"); 
        if (currentValue == maxSize)
        {
            return false;
        }
        else if(currentValue == minSize)
        {
            return false; 
        }
        return true; 
    }

    private void updateValue()
    {
        Debug.Log("UpdateValue");
        if (getXPosition() > defaultValue)
        {
            Debug.Log("Bigger Value");
            if (checkBounds())
            {
                currentValue++;
                Debug.Log("Value goes up");
            }
            
        }
        else if(getXPosition() < defaultValue)
        {
            Debug.Log("Smaller Value");
            if (checkBounds())
            {
                currentValue--;
                Debug.Log("Value goes down");
            }
            
        }
        else
        {
            Debug.Log("No Change"); 
        }
        
        //x position increase value
        //Increment by 1
    }



    public void checkHandleValue()
    {

    }
}
