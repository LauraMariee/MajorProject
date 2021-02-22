using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.Serialization;
using Valve.VR;

namespace Model
{
    public class ModelInformation : MonoBehaviour
    {
        private int bust;
        private int hips;
        private int waist;
        private int shoulder;
        private int neck;

        private const float MINScale = 0.8f;
        private const float MAXScale = 1.8f;

        public List<GameObject> bustBones = new List<GameObject>(); //get game objects for the chest
        public List<GameObject> hipBones = new List<GameObject>(); //get game objects for the chest
        public List<GameObject> waistBones = new List<GameObject>(); //get game objects for the chest
        public List<GameObject> shoulderBones = new List<GameObject>();
        public List<GameObject> neckBones = new List<GameObject>();
        
        private ModelSliders bustObject;
        private ModelSliders hipObject; 
        private ModelSliders waistObject; 
        private ModelSliders shoulderObject; 
        private ModelSliders neckObject;

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
        
        private void Update()
        {
            UpdateHandleValue(bustObject, hipObject, waistObject, shoulderObject, neckObject);
        }

        private float SetHandleValue(float minScale, float maxScale, ModelSliders handle, int currentValue)
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

        private void UpdateHandleValue(ModelSliders bustHandle, ModelSliders hipHandle, ModelSliders waistHandle, ModelSliders shoulderHandle, ModelSliders neckHandle)
        {
            foreach (var key in modelVariables)
            {
                var caseSwitch = key;

                switch (caseSwitch)
                {
                    case "bust":
                        bust = bustHandle.AssignText();
                        ScaleByValue(SetHandleValue(MINScale, MAXScale, bustHandle, bust), bustBones);
                        break;
                    case "hips":
                        hips = hipHandle.AssignText();
                        ScaleByValue(SetHandleValue(MINScale, MAXScale, hipHandle, hips), hipBones);
                        break;
                    case "waist":
                        waist = waistHandle.AssignText();
                        ScaleByValue(SetHandleValue(MINScale, MAXScale, waistHandle, waist), waistBones);
                        break;
                    case "shoulder":
                        shoulder = shoulderHandle.AssignText();
                        ScaleByValueShoulder(SetHandleValue(MINScale, MAXScale, shoulderHandle, shoulder), shoulderBones);
                        break;
                    case "neck":
                        neck = neckHandle.AssignText();
                        ScaleByValue(SetHandleValue(MINScale, MAXScale, neckHandle, neck), neckBones);
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
        
        private static void ScaleByValueShoulder(float scaleValue, IEnumerable<GameObject> bones)
        {
            foreach (var bone in bones)
            {
                bone.transform.localScale *= scaleValue;
                //to keep this child the same size you would need to do the following;
                bone.GetComponentInChildren<Transform>().localScale *= 1.0f / scaleValue;
                // 1.5f could (and should) obviously be a variable instead of a number
            }
        }
    }
}
