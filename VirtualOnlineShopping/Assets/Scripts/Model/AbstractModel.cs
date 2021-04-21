using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Model
{
    public class AbstractModel : MonoBehaviour
    {
        private readonly ModelInformation modelInformation = new ModelInformation();
        
        public Vector3 topSpawn;
        public Vector3 bottomSpawn;
        
        private void Start()
        {
            modelInformation.Start();
            if (GetComponent<FemaleModel>())
            {
                SetBones("FemaleModel");
            }
            if (GetComponent<MaleModel>())
            {
                SetBones("MaleModel");
            }
            SetSpawnPoints();
        }
        private void SetBones(string gender)
        {
            var model = this.gameObject; 
            switch (gender)
            {
                case "FemaleModel":
                {
                    var activeModel = model.GetComponent<FemaleModel>();
                    var boneDictionary = activeModel.GetBones();
                
                    FindAndAddBoneToList(boneDictionary.ElementAt(0).Key, boneDictionary.ElementAt(0).Value, modelInformation.bustBones);
                    FindAndAddBoneToList(boneDictionary.ElementAt(1).Key, boneDictionary.ElementAt(1).Value, modelInformation.hipBones);
                    FindAndAddBoneToList(boneDictionary.ElementAt(2).Key, boneDictionary.ElementAt(2).Value, modelInformation.waistBones);
                    FindAndAddBoneToList(boneDictionary.ElementAt(3).Key, boneDictionary.ElementAt(3).Value, modelInformation.shoulderBones);
                    FindAndAddBoneToList(boneDictionary.ElementAt(4).Key, boneDictionary.ElementAt(4).Value, modelInformation.neckBones);
                    break;
                }
                case "MaleModel":
                {
                    var activeModel = model.GetComponent<MaleModel>();
                    var boneDictionary = activeModel.GetBones();
                    
                    FindAndAddBoneToList(boneDictionary.ElementAt(0).Key, boneDictionary.ElementAt(0).Value, modelInformation.bustBones);
                    FindAndAddBoneToList(boneDictionary.ElementAt(1).Key, boneDictionary.ElementAt(1).Value, modelInformation.hipBones);
                    FindAndAddBoneToList(boneDictionary.ElementAt(2).Key, boneDictionary.ElementAt(2).Value, modelInformation.waistBones);
                    FindAndAddBoneToList(boneDictionary.ElementAt(3).Key, boneDictionary.ElementAt(3).Value, modelInformation.shoulderBones);
                    FindAndAddBoneToList(boneDictionary.ElementAt(4).Key, boneDictionary.ElementAt(4).Value, modelInformation.neckBones);
                    break;
                }
            }
        }
        private static void FindAndAddBoneToList(string boneOneAddress, string boneTwoAddress, ICollection<GameObject> boneList)
        {
            var boneOne = GameObject.Find(boneOneAddress);
            var boneTwo = GameObject.Find(boneTwoAddress);
            
            boneList.Add(boneOne);
            boneList.Add(boneTwo);
        }
        private void Update()
        {
            if (GetComponent<FemaleModel>())
            {
                modelInformation.UpdateHandleValue(modelInformation.bustSliderObject, modelInformation.hipSliderObject, modelInformation.waistSliderObject, 
                                modelInformation.shoulderSliderObject, modelInformation.neckSliderObject, 0.8f, 1.7f, 0.1961863f, 0.5f);
            }else if (GetComponent<MaleModel>())
            {
                modelInformation.UpdateHandleValue(modelInformation.bustSliderObject, modelInformation.hipSliderObject, modelInformation.waistSliderObject, 
                    modelInformation.shoulderSliderObject, modelInformation.neckSliderObject, 1f, 1.9f, 0.002f, 0.0035f);
            }
            
        }
        private void SetSpawnPoints()
        {
            topSpawn = GameObject.Find("ClothingSpawnPoints/TopPosition").GetComponent<Vector3>();
            bottomSpawn = GameObject.Find("ClothingSpawnPoints/BottomPosition").GetComponent<Vector3>();
        }
    }
}
