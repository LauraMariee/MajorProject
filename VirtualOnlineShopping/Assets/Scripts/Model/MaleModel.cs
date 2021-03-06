using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    public class MaleModel : MonoBehaviour
    {
        private readonly List<GameObject> returnList = new List<GameObject>();
        
        private readonly Dictionary<string, string> boneDictionary = new Dictionary<string, string>()
        {
            {"MaleModel/male/armature/Stomach/ChestLeft", "MaleModel/male/armature/Stomach/ChestRight"},
            {"FemaleModel/woman/armature/spine/hipLeft","FemaleModel/woman/armature/spine/hipRight"},
            {"MaleModel/male/armature/WaistLeft","MaleModel/male/armature/WaistRight"},
            {"MaleModel/male/armature/LeftShoulderTop","MaleModel/male/armature/RightShoulderTop"}, 
            {"MaleModel/male/armature/NeckLeft","MaleModel/male/armature/NeckRight"}
        };
        
        
        
        private GameObject boneOne;
        private GameObject boneTwo;

        private List<GameObject> BoneList(string boneOneAddress, string boneTwoAddress)
        {
            returnList.Clear();
            
            boneOne = GameObject.Find(boneOneAddress);
            boneTwo = GameObject.Find(boneTwoAddress);
            
            returnList.Add(boneOne);
            returnList.Add(boneTwo);

            return returnList;
        }


        public void AssignBones()
        {
            foreach (var body in boneDictionary)
            {
                BoneList(body.Key, body.Value); 
            }
        }
    }
}

