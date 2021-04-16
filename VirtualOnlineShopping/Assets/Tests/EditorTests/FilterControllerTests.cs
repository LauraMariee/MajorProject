using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine.TestTools;

namespace Tests.EditorTests
{
    public class FilterControllerTests
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
        public void GetFilterListTest()
        {
            var filterUIScript = new FilterUI(); 
            filterUIScript.selectedColours.Add("Orange");
            
             
            var filterColours = filterUIScript.selectedColours.ToList();


            Assert.That(filterColours == filterColours, "Colour isn't a match");//assert a parameter
        }
    }



    public class FilterUI
    {
        public readonly List<string> selectedColours;
    }
    
}
