using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Model
{
    public class MaleModel : MonoBehaviour
    {
        public readonly Dictionary<string, string> boneDictionary = new Dictionary<string, string>()
        {
            {"MaleModel/armature/stomach/chestLeft", "MaleModel/armature/stomach/chestRight"},
            {"MaleModel/armature/hipLeft","MaleModel/armature/hipRight"},
            {"MaleModel/armature/waistLeft","MaleModel/armature/waistRight"},
            {"MaleModel/armature/leftUpperArm","MaleModel/armature/rightUpperArm"}, 
            {"MaleModel/armature/neckLeft","MaleModel/armature/neckRight"}
        };
        
        public Dictionary<string, string> GetBones()
        {
            return boneDictionary;
        }
    }
}

