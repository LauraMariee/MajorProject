using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Model
{
    public class ModelInformation : MonoBehaviour
    {
        private static int _bust;
        public int hips;
        public int waist;
        public int shoulder;
        public int neck;

        private const string Root = "stand/";

        public List<string> bodyObjectList = new List<string>(){ "BustHandle", "HipHandle", "WaistHandle", "ShoulderHandle", "NeckHandle"}; //Keep this order
        public List<string> integerNameList = new List<string>() {"bust", "hips", "waist", "shoulder", "neck"}; //keep this order

        public List<GameObject> chest = new List<GameObject>(); //get game objects for the chest
        
        private ModelSliders modelSlider;
        
        private void CreateGameObjects()
        {
            foreach (var key in bodyObjectList)
            {
                var keyObject = GameObject.Find(CreateString(Root, key));//create and find new gameObject
                modelSlider = keyObject.GetComponent<ModelSliders>();
                foreach (var integerName in integerNameList)
                {
                    switch (integerName)
                    {
                        case "bust":
                            EditBust(modelSlider, _bust);
                            break;
                        case "hips":
                            hips = keyObject.GetComponent<ModelSliders>().AssignText();
                            break;
                        case "waist":
                            waist = keyObject.GetComponent<ModelSliders>().AssignText();
                            break;
                        case "shoulder":
                            shoulder = keyObject.GetComponent<ModelSliders>().AssignText();
                            break;
                        case "neck":
                            neck = keyObject.GetComponent<ModelSliders>().AssignText();
                            break;
                    }
                }
            }
        }
        
        private static string CreateString(string rootString, string key)
        {
            var newString = rootString + key;
            return newString;
        }


        // Update is called once per frame
        private void FixedUpdate()
        {
            CreateGameObjects();
        }


        private static void EditBust(ModelSliders modelSliderObject, int currentValue)
        {
            _bust = modelSliderObject.AssignText();
            
            const float minScale = 0.8f; //set range of scale - min and max 
            const float maxScale = 1.3f; //set range of scale - min and max 

            float minSize = modelSliderObject.GetMinSize();//set range of values - min and max
            float maxSize = modelSliderObject.GetMaxSize();//set range of values - min and max

            var fraction = (currentValue - minSize) / (maxSize - minSize);

            var value = minScale + fraction * (maxScale - minScale);//change scale
            Debug.Log(value);
        }
        
    }
}
