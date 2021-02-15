using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Model
{
    public class ModelInformation : MonoBehaviour
    { 
        public int bust;
        public int hips;
        public int waist;
        public int shoulder;
        public int neck;

        private const string Root = "stand/";

        public List<string> bodyObjectList = new List<string>(){ "BustHandle", "HipHandle", "WaistHandle", "ShoulderHandle", "NeckHandle"}; //Keep this order
        public List<string> integerNameList = new List<string>() {"bust", "hips", "waist", "shoulder", "neck"}; //keep this order

        private void CreateGameObjects()
        {
            foreach (var key in bodyObjectList)
            {
                var keyObject = GameObject.Find(CreateString(Root, key));//create and find new gameObject
                foreach (var integerName in integerNameList)
                {
                    switch (integerName)
                    {
                        case "bust":
                            bust = keyObject.GetComponent<ModelSliders>().AssignText();
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
        private void Update()
        {
            CreateGameObjects();
        }
        
        
    }
}
