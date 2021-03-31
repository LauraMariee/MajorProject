using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Model
{
    public class FemaleModel : MonoBehaviour
    {
        public readonly Dictionary<string, string> boneDictionary = new Dictionary<string, string>()
        {
            {"FemaleModel/armature/spine/stomach/chestLeft", "FemaleModel/armature/spine/stomach/chestRight"},
            {"FemaleModel/armature/spine/hipLeft","FemaleModel/armature/spine/hipRight"},
            {"FemaleModel/armature/spine/pelvis/waistLeft","FemaleModel/armature/spine/pelvis/waistRight"},
            {"FemaleModel/armature/spine/stomach/chest/leftUpperArm","FemaleModel/armature/spine/stomach/chest/rightUpperArm"}, 
            {"FemaleModel/armature/spine/stomach/chest/neck/neckLeft","FemaleModel/armature/spine/stomach/chest/neck/neckRight"}
        };

        public Dictionary<string, string> GetBones()
        {
            return boneDictionary;
        }
    }
}