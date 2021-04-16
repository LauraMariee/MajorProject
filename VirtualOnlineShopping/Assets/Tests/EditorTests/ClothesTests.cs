using System.Collections;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using UnityEngine.TestTools;


namespace Tests
{
    public class ClothesTests
    { 
        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator NewTestScriptWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }

        [Test]
        public void AssignToObjectTest()
        {
            var clothingObjectTest = new ClothingObject(); //Test clothes object
            var clothingDetailTest = new ClothingDetail {id = 1}; //create cloth to assign 

            clothingObjectTest.id = clothingDetailTest.id;
            
            Assert.That(clothingObjectTest.id == 1, "ClothingID isn't a match");//assert a parameter
        }
    }

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
    
    public class Price
    {
        public Current current{ get; set; }
    }
    
    public class Current
    {
        public float value { get; set; }
        public string text { get; set; }
    }
    
    public class ClothingDetail
    {
        public int id { get; set; } 
        public string itemName{get; set;}
        public float price{get; set;}
        public string brandName{get; set;}
        public int productCode{get; set;}
        public string url{get; set;}
        public string imageUrl{get; set;}
        public string itemType{get; set;}
        public List<string> customColours{get; set;}
    }
}
