using System;
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
        private string type;
        
        public float upperPrice;
        public float lowerPrice;
        private string priceName; //Used to get button and change it's colour

        public List<string> selectedColours;
        public List<string> selectedBrands;
        public List<string> selectedType;

        private string buttonOverview;
        public static string detailMenu;


        public void BrandClick()
        {
            brandName = EventSystem.current.currentSelectedGameObject.name; //Get name of the gameObject
            var brandButton = GameObject.Find(brandName).GetComponent<Button>();
            var brandButtonBlock = brandButton.colors; 
            
            if (selectedBrands.Contains(brandName))
            {
                selectedBrands.Remove(brandName);
                brandButtonBlock.selectedColor = Color.red; //Remove highlight
                brandButton.colors = brandButtonBlock;
                //Debug.Log("Removed " + colour);
            }
            else if (!selectedBrands.Contains(brandName))
            {
                selectedBrands.Add(brandName);
                brandButtonBlock.selectedColor = Color.green; //Add highlight
                brandButton.colors = brandButtonBlock;
                //Debug.Log("Added " + colour);
            }
            
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
        public void PriceClick()
        {
            priceName = EventSystem.current.currentSelectedGameObject.name; //Get name of the gameObject
            var priceButton = GameObject.Find(priceName).GetComponent<Button>();
            var priceButtonBlock = priceButton.colors;
            
             //Set variables
            var priceString = priceName.Split("-"[0]);
            var lowerRange = int.Parse(priceString[0].Trim());
            var upperRange = int.Parse(priceString[1].Trim());
            
            //replace + change colour
            upperPrice = upperRange;
            lowerPrice = lowerRange;
            
            priceButtonBlock.selectedColor = Color.green; //Add highlight
            priceButton.colors = priceButtonBlock;

        }
        public void TypeClick()
        {
            type = EventSystem.current.currentSelectedGameObject.name; //Get name of the gameObject
            var priceButton = GameObject.Find(type).GetComponent<Button>();
            var priceButtonBlock = priceButton.colors;
            
            if (selectedType.Contains(type))
            {
                selectedType.Remove(type);
                priceButtonBlock.selectedColor = Color.red; //Remove highlight
                priceButton.colors = priceButtonBlock;
                Debug.Log("Removed " + type);
            }
            else if (!selectedType.Contains(type))
            {
                selectedType.Add(type);
                priceButtonBlock.selectedColor = Color.green; //Add highlight
                priceButton.colors = priceButtonBlock;
                Debug.Log("Added " + type);
            }
        }
        public void DetailPanelClick()
        {
            buttonOverview = EventSystem.current.currentSelectedGameObject.name; //Get name of the gameObject
           // Debug.Log("current button is " + buttonOverview);
            var button = GameObject.Find(buttonOverview).GetComponent<Button>();
            var buttonBlock = button.colors;
            
            switch (buttonOverview)
            {
                case "Colour":
                    buttonBlock.selectedColor = Color.green; //Add highlight
                    button.colors = buttonBlock;
                    detailMenu = "Colour";
                    ShowDetailMenu();
                    break;
                case "Brand":
                    buttonBlock.selectedColor = Color.green; //Add highlight
                    button.colors = buttonBlock;
                    detailMenu = "Brand";
                    ShowDetailMenu();
                    break;
                case "Price":
                    buttonBlock.selectedColor = Color.green; //Add highlight
                    button.colors = buttonBlock;
                    detailMenu = "Price";
                    ShowDetailMenu();
                    break;
                case "Type":
                    buttonBlock.selectedColor = Color.green; //Add highlight
                    button.colors = buttonBlock;
                    detailMenu = "Type";
                    ShowDetailMenu();
                    break;
                default:
                    detailMenu = "Empty";
                    break;
            }
            //switch statement on button clicked 
        }
        private static void ShowDetailMenu()
        {
            var detailPanel = GameObject.Find("UI/Canvas/FilterUI/DetailsMenu/Viewport/Content/" + detailMenu);//find detail model check
            
            var detailContent = GameObject.Find("UI/Canvas/FilterUI/DetailsMenu/Viewport/Content");
            var childLimit = detailContent.transform.childCount;
            
          //  Debug.Log("There are " + childLimit + " children");


            if (detailPanel.activeInHierarchy) return;
            for (var i = 0; i < childLimit; i++)//check if any children are active. 
            {
                detailContent.transform.GetChild(i).gameObject.SetActive(false);
            //    Debug.Log("Child " + i + " is disabled");
                
            }
            detailPanel.SetActive(true);
        }
    }
}
