using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Valve.VR;

namespace Model
{
    public class ModelInformation : MonoBehaviour
    {
        private int bust;
        public int hips;
        public int waist;
        public int shoulder;
        public int neck;

        public List<GameObject> chestObject = new List<GameObject>(); //get game objects for the chest

        private GameObject bustObject;
        private GameObject hipObject; 
        private GameObject waistObject; 
        private GameObject shoulderObject; 
        private GameObject neckObject; 
        
        public void Start()
        {
            CreateGameObjects();
            SetHandleValue(0.8f, 1.3f, bustObject.GetComponent<ModelSliders>(), bust);
            SetHandleValue(0.8f, 1.3f, hipObject.GetComponent<ModelSliders>(), hips); 
            SetHandleValue(0.8f, 1.3f, waistObject.GetComponent<ModelSliders>(), waist); 
            SetHandleValue(0.8f, 1.3f, shoulderObject.GetComponent<ModelSliders>(), shoulder); 
            SetHandleValue(0.8f, 1.3f, neckObject.GetComponent<ModelSliders>(), neck); 
        }

        private void CreateGameObjects()
        {
            bustObject = GameObject.Find("BustHandle");
            hipObject = GameObject.Find("HipHandle");
            waistObject = GameObject.Find("WaistHandle");
            shoulderObject = GameObject.Find("ShoulderHandle");
            neckObject = GameObject.Find("NeckHandle");
        }
        

        // Update is called once per frame
        private void Update()
        {
            UpdateHandleValue(bustObject.GetComponent<ModelSliders>());
        }


        private static float SetHandleValue(float minScale, float maxScale, ModelSliders handle, int currentValue)
        {
            float minSize = handle.minSize;//set range of values - min and max
            float maxSize = handle.maxSize;//set range of values - min and max
            var fraction = (currentValue - minSize) / (maxSize - minSize);
            var value = minScale + fraction * (maxScale - minScale); //change scale
            return value;
        }

        private void UpdateHandleValue(ModelSliders handle)
        {
            bust = handle.AssignText();
            ScaleChestByValue(SetHandleValue(0.8f, 1.3f, handle.GetComponent<ModelSliders>(), bust));
            
        }

        

        private void ScaleChestByValue(float scaleValue)
        {
            foreach (var bone in chestObject)
            {
                Debug.Log(bone.GetComponent<Transform>().localScale = new Vector3(scaleValue, scaleValue, scaleValue));
            }
        }
        
    }
}
