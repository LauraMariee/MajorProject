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
        private string brandName; //Get from FilterUI
        private string name; //Get from FilterUI
        
        private void Start()
        {
            clothesMasterScriptObject = GameObject.Find("Environment");
            clothesMasterScript = clothesMasterScriptObject.GetComponent<ClothesMasterScript>();//Find ClothesMasterScript
            ClothesMasterScript.GetLoadedClothes();

            filterScriptObject = GameObject.Find("UI/Canvas/FilterUI");
            filterUIScript = filterScriptObject.GetComponent<FilterUI>();

            colourMenu = "Colour1";
        }
        private void GetColours()
        {
            filterColours = filterUIScript.selectedColours;
        }
        
        public void Search()
        {
            Debug.Log("Search Clicked");
            GetColours();
            CheckForDetails();
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

        private void CheckForDetails(){
            clothesList = ClothesMasterScript.GetLoadedClothes();
            foreach (var clothItem in clothesList)//Go through all loaded clothes,
            {
                if (clothItem.customColours.Any(cloth => filterColours.Any(colour => cloth == colour)))
                {
                    Debug.Log("Added to filtered list: " + clothItem.name);;
                    filteredClothesList?.Add(clothItem);
                }
                else if(clothItem.brandName == brandName)
                {
                    filteredClothesList?.Add(clothItem); //put in new list
                }
                else if(clothItem.name == name)
                {
                    filteredClothesList?.Add(clothItem); //put in new list
                }
                else if(clothItem.price.current.value < filterUIScript.LowerRangeCheck() && clothItem.price.current.value > 
                    filterUIScript.UpperRangeCheck())//Get two values and check if model price is between the two prices
                {
                    filteredClothesList?.Add(clothItem); //put in new list
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
        
        

        // Update is called once per frame
        private void Update()
        {
            GetColours();
        }
    }
}