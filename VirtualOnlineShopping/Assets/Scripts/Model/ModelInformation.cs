using System.Collections.Generic;
using UnityEngine;


namespace Model
{
    public class ModelInformation
    {
        
        private int bustMeasurement;
        private int hipsMeasurement;
        private int waistMeasurement;
        private int shoulderMeasurement;
        private int neckMeasurement;

        private const float MINScale = 0.8f;
        private const float MAXScale = 1.8f;

        public readonly List<GameObject> bustBones = new List<GameObject>();
        public readonly List<GameObject> hipBones = new List<GameObject>(); 
        public readonly List<GameObject> waistBones = new List<GameObject>(); 
        public readonly List<GameObject> shoulderBones = new List<GameObject>();
        public readonly List<GameObject> neckBones = new List<GameObject>();
        
        public ModelSlider bustSliderObject;
        public ModelSlider hipSliderObject; 
        public ModelSlider waistSliderObject; 
        public ModelSlider shoulderSliderObject; 
        public ModelSlider neckSliderObject;

        private readonly List<string> modelVariables = new List<string>() { "bust", "hips", "waist", "shoulder", "neck"};
        
        public void Start()
        {
            CreateSliderObjects();
            SetHandleValue(MINScale, MAXScale, bustSliderObject, bustMeasurement);
            SetHandleValue(MINScale, MAXScale, hipSliderObject, hipsMeasurement); 
            SetHandleValue(MINScale, MAXScale, waistSliderObject, waistMeasurement); 
            SetHandleValue(MINScale, MAXScale, shoulderSliderObject, shoulderMeasurement); 
            SetHandleValue(MINScale, MAXScale, neckSliderObject, neckMeasurement);
        }

        private void CreateSliderObjects()
        {
            bustSliderObject = GameObject.Find("BustHandle").GetComponent<ModelSlider>();
            hipSliderObject = GameObject.Find("HipHandle").GetComponent<ModelSlider>();
            waistSliderObject = GameObject.Find("WaistHandle").GetComponent<ModelSlider>();
            shoulderSliderObject = GameObject.Find("ShoulderHandle").GetComponent<ModelSlider>();
            neckSliderObject = GameObject.Find("NeckHandle").GetComponent<ModelSlider>();
        }

        private static float SetHandleValue(float minScale, float maxScale, ModelSlider handle, int currentValue)
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

        public void UpdateHandleValue(ModelSlider bustHandle, ModelSlider hipHandle, ModelSlider waistHandle, ModelSlider shoulderHandle, 
            ModelSlider neckHandle, float minScale, float maxScale, float minShoulder, float maxShoulder)
        {
            foreach (var key in modelVariables)
            {
                var caseSwitch = key;

                switch (caseSwitch)
                {
                    case "bust":
                        bustMeasurement = bustHandle.AssignText(); //getters and setters
                        ScaleByValue(SetHandleValue(minScale, maxScale, bustHandle, bustMeasurement), bustBones);
                        break;
                    case "hips":
                        hipsMeasurement = hipHandle.AssignText();
                        ScaleByValue(SetHandleValue(minScale, maxScale, hipHandle, hipsMeasurement), hipBones);
                        break;
                    case "waist":
                        waistMeasurement = waistHandle.AssignText();
                        ScaleByValue(SetHandleValue(minScale, maxScale, waistHandle, waistMeasurement), waistBones);
                        break;
                    case "shoulder":
                        shoulderMeasurement = shoulderHandle.AssignText();
                        ScaleByValueShoulder(SetHandleValue(minShoulder, maxShoulder, shoulderHandle, shoulderMeasurement),
                            SetHandleValue(-minShoulder, -maxShoulder, shoulderHandle, shoulderMeasurement), shoulderBones);
                        break;
                    case "neck":
                        neckMeasurement = neckHandle.AssignText();
                        ScaleByValue(SetHandleValue(minScale, maxScale, neckHandle, neckMeasurement), neckBones);
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
