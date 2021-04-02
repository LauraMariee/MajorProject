using System.Collections.Generic;
using Clothing;
using UnityEngine;

namespace Filtering
{
    
    public class FilterController : MonoBehaviour
    {
        private GameObject clothesMasterScriptObject;
        private GameObject filterScriptObject;
        
        private List<ClothingObject> clothesList;
        private List<ClothingObject> filteredClothesList;
        
        private ClothesMasterScript clothesMasterScript;
        private FilterUI filterUIScript;
        
        //Filter variables
        private string colour; //Get from FilterUI
        private string brandName; //Get from FilterUI
        private string name; //Get from FilterUI
        
        
        private void Start()
        {
            clothesMasterScriptObject = GameObject.Find("Environment");
            clothesMasterScript = clothesMasterScriptObject.GetComponent<ClothesMasterScript>();//Find ClothesMasterScript
            clothesMasterScript.GetLoadedClothes();

            filterScriptObject = GameObject.Find("UI/Canvas/FilterUI");
            filterUIScript = filterScriptObject.GetComponent<FilterUI>();
        }
        
        public void CheckForDetails(){
            clothesList = clothesMasterScript.GetLoadedClothes();
            foreach (var clothItem in clothesList)//Go through all loaded clothes,
            {
                if (clothItem.colour == colour)//check each for details,
                {
                    filteredClothesList.Add(clothItem);
                    break; //put in new list
                }
                else if(clothItem.brandName == brandName)
                {
                    filteredClothesList.Add(clothItem);
                    break; //put in new list
                }
                else if(clothItem.name == name)
                {
                    filteredClothesList.Add(clothItem);
                    break; //put in new list
                }
                else if(clothItem.price.value < filterUIScript.LowerRangeCheck() && clothItem.price.value > 
                    filterUIScript.UpperRangeCheck())//Get two values and check if model price is between the two prices
                {
                    filteredClothesList.Add(clothItem);
                    break; //put in new list
                }
                //load new list of clothes into the machine
                //show two at a time
            }
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
