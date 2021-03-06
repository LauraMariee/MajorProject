using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Model
{
    public class FemaleModel : MonoBehaviour
    {
        private readonly List<GameObject> returnList = new List<GameObject>();
        
        private readonly Dictionary<string, string> boneDictionary = new Dictionary<string, string>()
        {
            {"FemaleModel/woman/armature/spine/stomach/chestLeft", "FemaleModel/woman/armature/spine/stomach/chestRight"},
            {"FemaleModel/woman/armature/spine/hipLeft","FemaleModel/woman/armature/spine/hipRight"},
            {"FemaleModel/woman/armature/spine/pelvis/waistLeft","FemaleModel/woman/armature/spine/pelvis/waistRight"},
            {"FemaleModel/woman/armature/spine/stomach/chest/leftUpperArm","FemaleModel/woman/armature/spine/stomach/chest/rightUpperArm"}, 
            {"FemaleModel/woman/armature/spine/stomach/chest/neck/neckLeft","FemaleModel/woman/armature/spine/stomach/chest/neck/neckRight"}
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


        public void AssignFemaleBones()
        {
            foreach (var body in boneDictionary)
            {
                BoneList(body.Key, body.Value); 
            }
        }
    }
}