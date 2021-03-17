using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Model
{
    public class FemaleModel : MonoBehaviour
    {

        private readonly Dictionary<string, string> boneDictionary = new Dictionary<string, string>()
        {
            {"FemaleModel/woman/armature/spine/stomach/chestLeft", "FemaleModel/woman/armature/spine/stomach/chestRight"},
            {"FemaleModel/woman/armature/spine/hipLeft","FemaleModel/woman/armature/spine/hipRight"},
            {"FemaleModel/woman/armature/spine/pelvis/waistLeft","FemaleModel/woman/armature/spine/pelvis/waistRight"},
            {"FemaleModel/woman/armature/spine/stomach/chest/leftUpperArm","FemaleModel/woman/armature/spine/stomach/chest/rightUpperArm"}, 
            {"FemaleModel/woman/armature/spine/stomach/chest/neck/neckLeft","FemaleModel/woman/armature/spine/stomach/chest/neck/neckRight"}
        };

        private readonly ModelInformation modelInformation = new ModelInformation();
        
        private GameObject boneOne;
        private GameObject boneTwo;

        public void Start()
        {
            AssignBones();
            modelInformation.Start();
        }

        private void BoneList(string boneOneAddress, string boneTwoAddress, ICollection<GameObject> boneTotalList)
        {
            boneOne = GameObject.Find(boneOneAddress);
            boneTwo = GameObject.Find(boneTwoAddress);
            
            boneTotalList.Add(boneOne);
            boneTotalList.Add(boneTwo);
        }

        private void AssignBones()
        {
            BoneList(boneDictionary.ElementAt(0).Key, boneDictionary.ElementAt(0).Value, modelInformation.bustBones);
            BoneList(boneDictionary.ElementAt(1).Key, boneDictionary.ElementAt(1).Value, modelInformation.hipBones);
            BoneList(boneDictionary.ElementAt(2).Key, boneDictionary.ElementAt(2).Value, modelInformation.waistBones);
            BoneList(boneDictionary.ElementAt(3).Key, boneDictionary.ElementAt(3).Value, modelInformation.shoulderBones);
            BoneList(boneDictionary.ElementAt(4).Key, boneDictionary.ElementAt(4).Value, modelInformation.neckBones);
        }

        public void Update()
        {
            modelInformation.UpdateHandleValue(modelInformation.bustObject, modelInformation.hipObject, modelInformation.waistObject, 
                modelInformation.shoulderObject, modelInformation.neckObject, 0.8f, 1.7f, 0.1961863f, 0.5f);
        }
    }
}