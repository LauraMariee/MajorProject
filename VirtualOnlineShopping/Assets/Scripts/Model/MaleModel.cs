using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Model
{
    public class MaleModel : MonoBehaviour
    {
        
        private readonly Dictionary<string, string> boneDictionary = new Dictionary<string, string>()
        {
            {"MaleModel/armature/stomach/chestLeft", "MaleModel/armature/stomach/chestRight"},
            {"MaleModel/armature/hipLeft","MaleModel/armature/hipRight"},
            {"MaleModel/armature/waistLeft","MaleModel/armature/waistRight"},
            {"MaleModel/armature/leftUpperArm","MaleModel/armature/rightUpperArm"}, 
            {"MaleModel/armature/neckLeft","MaleModel/armature/neckRight"}
        };

        private GameObject boneOne;
        private GameObject boneTwo;
        
        private readonly ModelInformation modelInformation = new ModelInformation();
        
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
                modelInformation.shoulderObject, modelInformation.neckObject, 1f, 1.9f, 0.002f, 0.0035f);
        }
    }
}

