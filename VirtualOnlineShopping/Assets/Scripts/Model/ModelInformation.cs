using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.Serialization;
using Valve.VR;

namespace Model
{
    public class ModelInformation
    {
        private int bust;
        private int hips;
        private int waist;
        private int shoulder;
        private int neck;

        private const float MINScale = 0.8f;
        private const float MAXScale = 1.8f;

        public readonly List<GameObject> bustBones = new List<GameObject>();
        public readonly List<GameObject> hipBones = new List<GameObject>(); 
        public readonly List<GameObject> waistBones = new List<GameObject>(); 
        public readonly List<GameObject> shoulderBones = new List<GameObject>();
        public readonly List<GameObject> neckBones = new List<GameObject>();
        
        public ModelSliders bustObject;
        public ModelSliders hipObject; 
        public ModelSliders waistObject; 
        public ModelSliders shoulderObject; 
        public ModelSliders neckObject;

        private readonly List<string> modelVariables = new List<string>() { "bust", "hips", "waist", "shoulder", "neck"};
        
        public void Start()
        {
            CreateGameObjects();
            SetHandleValue(MINScale, MAXScale, bustObject, bust);
            SetHandleValue(MINScale, MAXScale, hipObject, hips); 
            SetHandleValue(MINScale, MAXScale, waistObject, waist); 
            SetHandleValue(MINScale, MAXScale, shoulderObject, shoulder); 
            SetHandleValue(MINScale, MAXScale, neckObject, neck);
        }

        private void CreateGameObjects()
        {
            bustObject = GameObject.Find("BustHandle").GetComponent<ModelSliders>();
            hipObject = GameObject.Find("HipHandle").GetComponent<ModelSliders>();
            waistObject = GameObject.Find("WaistHandle").GetComponent<ModelSliders>();
            shoulderObject = GameObject.Find("ShoulderHandle").GetComponent<ModelSliders>();
            neckObject = GameObject.Find("NeckHandle").GetComponent<ModelSliders>();
        }

        private static float SetHandleValue(float minScale, float maxScale, ModelSliders handle, int currentValue)
        {
            //set range of values - min and max
            float minSize = handle.GetMinSize();
            float maxSize = handle.GetMaxSize();
            
            //Debug.Log(minSize + " for " + handle.name );
            //Debug.Log(maxSize + " for " + handle.name );
            
            var fraction = (currentValue - minSize) / (maxSize - minSize);
            var value = minScale + fraction * (maxScale - minScale); //change scale
            return value;
        }

        public void UpdateHandleValue(ModelSliders bustHandle, ModelSliders hipHandle, ModelSliders waistHandle, ModelSliders shoulderHandle, ModelSliders neckHandle)
        {
            foreach (var key in modelVariables)
            {
                var caseSwitch = key;

                switch (caseSwitch)
                {
                    case "bust":
                        bust = bustHandle.AssignText();
                        ScaleByValue(SetHandleValue(0.8f, 1.5f, bustHandle, bust), bustBones);
                        break;
                    case "hips":
                        hips = hipHandle.AssignText();
                        ScaleByValue(SetHandleValue(0.8f, 1.8f, hipHandle, hips), hipBones);
                        break;
                    case "waist":
                        waist = waistHandle.AssignText();
                        ScaleByValue(SetHandleValue(0.8f, 1.6f, waistHandle, waist), waistBones);
                        break;
                    case "shoulder":
                        shoulder = shoulderHandle.AssignText();
                        ScaleByValueShoulder(SetHandleValue(0.1961863f, 0.5f, shoulderHandle, shoulder),
                            SetHandleValue(-0.1961863f, -0.5f, shoulderHandle, shoulder), shoulderBones);
                        break;
                    case "neck":
                        neck = neckHandle.AssignText();
                        ScaleByValue(SetHandleValue(MINScale, 2, neckHandle, neck), neckBones);
                        break;
                    default:
                        Debug.Log("No available handle to scale");
                        break;
                }
            }
            
        }
        
        private static void ScaleByValue(float scaleValue, IEnumerable<GameObject> bones)
        {
            foreach (var bone in bones)
            {
                bone.GetComponent<Transform>().localScale = new Vector3(scaleValue, scaleValue, scaleValue);
            }
        }
        
        private static void ScaleByValueShoulder(float xValueLeft, float xValueRight, IEnumerable<GameObject> bones)
        {
            foreach (var bone in bones)
            {
                var position = bone.transform.localPosition;
                switch (bone.name)
                {
                    case "leftUpperArm":
                        bone.GetComponent<Transform>().localPosition = new Vector3(xValueLeft, position.y, position.z );
                        break;
                    case "rightUpperArm":
                        bone.GetComponent<Transform>().localPosition = new Vector3(xValueRight, position.y, position.z );
                        break;
                }
            }
        }
        
    }
}
