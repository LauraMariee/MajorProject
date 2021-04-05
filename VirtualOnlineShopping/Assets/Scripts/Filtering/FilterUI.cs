using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Filtering
{
    public class FilterUI : MonoBehaviour
    {
        private string colour;
        private string brandName;
        private int price;

        public List<string> selectedColours;

        public float LowerRangeCheck()
        {
            const float minPrice = 0;
            return minPrice;//Get minprice
        }
        
        public float UpperRangeCheck()
        {
            const float maxPrice = 1;
            return maxPrice;//Get maxprice
        }
        
        public void ColourClick()
        {
            colour = EventSystem.current.currentSelectedGameObject.name; //Get name of the gameObject
            var colourButton = GameObject.Find(colour).GetComponent<Button>();
            var colorButtonBlock = colourButton.colors; 
            
             if (selectedColours.Contains(colour))
             {
                 selectedColours.Remove(colour);
                 colorButtonBlock.selectedColor = Color.red; //Remove highlight
                 colourButton.colors = colorButtonBlock;
                 //Debug.Log("Removed " + colour);
             }
             else if (!selectedColours.Contains(colour))
             {
                 selectedColours.Add(colour);
                 colorButtonBlock.selectedColor = Color.green; //Add highlight
                 colourButton.colors = colorButtonBlock;
                 //Debug.Log("Added " + colour);
             }
        }
    }
}
