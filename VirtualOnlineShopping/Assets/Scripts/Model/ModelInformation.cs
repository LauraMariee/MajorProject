using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.Serialization;
using Valve.VR;

namespace Model
{
    public class ModelInformation : MonoBehaviour
    {
        public string gender; 
        
        private int bust;
        private int hips;
        private int waist;
        private int shoulder;
        private int neck;

        private const float MINScale = 0.8f;
        private const float MAXScale = 1.8f;

        private readonly List<GameObject> bustBones = new List<GameObject>();
        private readonly List<GameObject> hipBones = new List<GameObject>(); 
        private readonly List<GameObject> waistBones = new List<GameObject>(); 
        private readonly List<GameObject> shoulderBones = new List<GameObject>();
        private readonly List<GameObject> neckBones = new List<GameObject>();
        
        private ModelSliders bustObject;
        private ModelSliders hipObject; 
        private ModelSliders waistObject; 
        private ModelSliders shoulderObject; 
        private ModelSliders neckObject;

        private readonly List<string> modelVariables = new List<string>() { "bust", "hips", "waist", "shoulder", "neck"};
        
        public void Start()
        {
            FindAndAssignBones();
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

        private void UpdateHandleValue(ModelSliders bustHandle, ModelSliders hipHandle, ModelSliders waistHandle, ModelSliders shoulderHandle, ModelSliders neckHandle)
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


        private void SetFemaleBones()
        {
            var bustBoneOne = GameObject.Find("FemaleModel/woman/armature/spine/stomach/chestLeft");
            var bustBoneTwo = GameObject.Find("FemaleModel/woman/armature/spine/stomach/chestRight");
            
            var hipBoneOne = GameObject.Find("FemaleModel/woman/armature/spine/hipLeft");
            var hipBoneTwo = GameObject.Find("FemaleModel/woman/armature/spine/hipRight");
            
            var waistBoneOne = GameObject.Find("FemaleModel/woman/armature/spine/pelvis/waistLeft");
            var waistBoneTwo = GameObject.Find("FemaleModel/woman/armature/spine/pelvis/waistRight");
            
            var shoulderBoneOne = GameObject.Find("FemaleModel/woman/armature/spine/stomach/chest/leftUpperArm");
            var shoulderBoneTwo = GameObject.Find("FemaleModel/woman/armature/spine/stomach/chest/rightUpperArm");
            
            var neckBoneOne = GameObject.Find("FemaleModel/woman/armature/spine/stomach/chest/neck/neckLeft");
            var neckBoneTwo = GameObject.Find("FemaleModel/woman/armature/spine/stomach/chest/neck/neckRight");
            
            bustBones.Add(bustBoneOne);
            bustBones.Add(bustBoneTwo);
            
            hipBones.Add(hipBoneOne);
            hipBones.Add(hipBoneTwo);
            
            waistBones.Add(waistBoneOne);
            waistBones.Add(waistBoneTwo);
            
            shoulderBones.Add(shoulderBoneOne);
            shoulderBones.Add(shoulderBoneTwo);
            
            neckBones.Add(neckBoneOne);
            neckBones.Add(neckBoneTwo);
        }
        
        
        private void SetMaleBones()
        {
            var bustBoneOne = GameObject.Find("MaleModel/male/armature/Stomach/chestLeft");
            var bustBoneTwo = GameObject.Find("MaleModel/male/armature/Stomach/chestRight");
            
            var hipBoneOne = GameObject.Find("MaleModel/male/armature/HipLeft");
            var hipBoneTwo = GameObject.Find("MaleModel/male/armature/HipRight");
            
            var waistBoneOne = GameObject.Find("MaleModel/male/armature/WaistLeft");
            var waistBoneTwo = GameObject.Find("MaleModel/male/armature/WaistRight");
            
            var shoulderBoneOne = GameObject.Find("MaleModel/male/armature/LeftShoulderTop");
            var shoulderBoneTwo = GameObject.Find("MaleModel/male/armature/RightShoulderTop");
            
            var neckBoneOne = GameObject.Find("MaleModel/male/armature/NeckLeft");
            var neckBoneTwo = GameObject.Find("MaleModel/male/armature/NeckRight");
            
            bustBones.Add(bustBoneOne);
            bustBones.Add(bustBoneTwo);
            
            hipBones.Add(hipBoneOne);
            hipBones.Add(hipBoneTwo);
            
            waistBones.Add(waistBoneOne);
            waistBones.Add(waistBoneTwo);
            
            shoulderBones.Add(shoulderBoneOne);
            shoulderBones.Add(shoulderBoneTwo);
            
            neckBones.Add(neckBoneOne);
            neckBones.Add(neckBoneTwo);
        }
        

        private void FindAndAssignBones()
        {
            Debug.Log(name);
            //Remove "(Clone)"
            switch (this.name)
            {
                // check current name
                case "FemaleModel":
                    SetFemaleBones();
                    break;
                case "MaleModel":
                    SetMaleBones();
                    break;
            }

            //Find current model 
            //Link all relevant bones
        }
    }
}
