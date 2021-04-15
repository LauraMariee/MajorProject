using System.Collections;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using UnityEngine.TestTools;
using Valve.Newtonsoft.Json;

namespace Tests
{
    public class ClothesTests
    {
        // A Test behaves as an ordinary method
        [Test]
        public void NewTestScriptSimplePasses()
        {
            // Use the Assert class to test conditions
        }

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
        public void TestMethod()
        {
            var numberOne = 1;
            var numberTwo = 1;

            Assert.That(numberOne == numberTwo, "numbers are not equal");
        }
        
        [Test]
        public void AssignToGameObjectTest()
        {
            //Test list of loaded clothes
            //assert a parameter
        }
    }
}
