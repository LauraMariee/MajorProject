using System.Diagnostics.Contracts;
using UnityEngine;

namespace Clothing
{
    public class ClothingDetail : MonoBehaviour
    {
        public int id { get; set; } 
        public string itemName{get; set;}
        public float price{get; set;}
        public string colour{get; set;}
        public string brandName{get; set;}
        public int productCode{get; set;}
        public string url{get; set;}
        public string imageUrl{get; set;}
        public string itemType{get; set;}
    }
}
