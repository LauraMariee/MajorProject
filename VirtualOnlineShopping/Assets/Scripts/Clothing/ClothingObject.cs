using System;
using System.Collections.Generic;
using UnityEngine;

namespace Clothing
{
    [Serializable]
    public class CategorySearchResult
    {
        public string categoryName{ get; set; }
        public List<ClothingObject> products { get; set; }
    }
    public class Price
    {
        public Current current{ get; set; }
    }
    
    [Serializable] 
    public class Current
    {
        public float value { get; set; }
        public string text { get; set; }
    }
    
    
    [Serializable]
    public class ClothingObject
    {
        public int id { get; set; } 
        public string name{get; set;}
        public Price price{get; set;}
        public string brandName{get; set;}
        public int productCode{get; set;}
        public string url{get; set;}
        public string imageUrl{get; set;}
        public string itemType{get; set;}
        public List<string> customColours{get; set;}

    }
}
