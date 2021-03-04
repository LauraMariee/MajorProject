using System;
using UnityEngine;
using UnityEngine.UI;

namespace Model
{
    public class ModelSliders : MonoBehaviour
    {
        public int minSize;
        public int maxSize;

        private GameObject startPoint;
        private GameObject endPoint;

        public GameObject physicalHandle;

        public Text handleText;

        private int PositionToValue(Vector3 position)
        {
            var newPosition = position.x;
            var startPosition = startPoint.GetComponent<Transform>().position.x;
            var endPosition = endPoint.GetComponent<Transform>().position.x;
            var fraction = (newPosition - startPosition) / (endPosition - startPosition);

            var value = minSize + fraction * (maxSize - minSize);
            return Mathf.RoundToInt(value);
        }

        private Vector3 ValueToPosition(float value)
        {
            var fraction = (value - minSize) / (maxSize - minSize);

            var startPosition = startPoint.GetComponent<Transform>().position;
            var endPosition = endPoint.GetComponent<Transform>().position;
            var position = startPosition + (endPosition - startPosition) * fraction;
            return position;
        }
    
        private void Start()
        {
            startPoint = GameObject.Find("Start");
            endPoint = GameObject.Find("End");
        }

        private Vector3 GetHandlePosition()
        {
            var handlePosition = physicalHandle.GetComponent<Transform>().position;
            return handlePosition;
        }
        
        public int GetMinSize()
        {
            return minSize;
        }
        
        public int GetMaxSize()
        {
            return maxSize; 
        }

        private void Update()
        {
            AssignText();
        }


        public void FindAndAssignBones()
        {
            
        }
            

        public int AssignText()
        {
            var positionValue = PositionToValue(GetHandlePosition());
            handleText.text = positionValue.ToString(); 
            //Debug.Log(positionValue);
            return positionValue;
        }

    }
}
