using System.Collections.Generic;
using System.Linq;
using Clothing;
using UnityEngine;

namespace Filtering
{
    
    public class FilterController : MonoBehaviour
    {
        private GameObject clothesMasterScriptObject;
        private GameObject filterScriptObject;
        
        private List<ClothingObject> clothesList;
        private List<ClothingObject> filteredClothesList = new List<ClothingObject>();
        
        private ClothesMasterScript clothesMasterScript;
        private FilterUI filterUIScript;
        
        private string colourMenu;
        private GameObject colourMenuObject;
        
        //Filter variables
        private List<string> filterColours; //Get from FilterUI
        private List<string> filterBrandNames; //Get from FilterUI
        private string name; //Get from FilterUI
        
        private void Start()
        {
            clothesMasterScriptObject = GameObject.Find("Environment");
            clothesMasterScript = clothesMasterScriptObject.GetComponent<ClothesMasterScript>();//Find ClothesMasterScript
            ClothesMasterScript.GetLoadedClothes();

            filterScriptObject = GameObject.Find("UI/Canvas/FilterUI");
            filterUIScript = filterScriptObject.GetComponent<FilterUI>();

            colourMenu = "Colour";
        }
        private void GetFilterLists()
        {
            filterColours = filterUIScript.selectedColours;
            filterBrandNames = filterUIScript.selectedBrands;
        }
        
        public void Search()
        {
            Debug.Log("Search Clicked");
            GetFilterLists();
            FilterClothes();
        }
        
        private static bool DetailMenuCheck()
        {
            var detailPanel = GameObject.Find("UI/Canvas/FilterUI/detailsMenu");//find detail model check
            return detailPanel.activeInHierarchy;//if detail model is active return true else false
        }
        
        public void OpenColourDetailPanel()
        {
            colourMenuObject = GameObject.Find("DetailsMenu/Viewport/Content/" + colourMenu); //find gameobject on name
            //Hide other open colours
        }

        private void FilterClothes(){
            clothesList = ClothesMasterScript.GetLoadedClothes();
            foreach (var clothItem in clothesList)//Go through all loaded clothes,
            {
                if (clothItem.customColours.Any(cloth => filterColours.Any(colour => cloth == colour)))
                {
                    Debug.Log("Added to filtered list: " + clothItem.name);;
                    if (!IsInList(clothItem))
                    {
                        filteredClothesList?.Add(clothItem);
                    }
                }
                else if (filterBrandNames.Any(brand => clothItem.brandName == brand))
                {
                    Debug.Log("Added to filtered list: " + clothItem.name);;
                    if (!IsInList(clothItem))
                    {
                        filteredClothesList?.Add(clothItem);
                    }
                }
                else if(clothItem.name == name)
                {
                    if (!IsInList(clothItem))
                    {
                        filteredClothesList?.Add(clothItem);
                    }
                }
                else if(clothItem.price.current.value < filterUIScript.LowerRangeCheck() && clothItem.price.current.value > 
                    filterUIScript.UpperRangeCheck())//Get two values and check if model price is between the two prices
                {
                    if (!IsInList(clothItem))
                    {
                        filteredClothesList?.Add(clothItem);
                    }
                }

                if (filteredClothesList == null) continue;
                foreach (var clothing in filteredClothesList)
                {
                    Debug.Log(clothing.name);
                }
                //load new list of clothes into the machine
                //show two at a time
            }
        }

        private bool IsInList(ClothingObject cloth)
        {
            return filteredClothesList.Contains(cloth);
        }
        // Update is called once per frame
        private void Update()
        {
            GetFilterLists();
        }
    }
}