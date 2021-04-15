using System.Collections.Generic;
using System.Linq;
using Clothing;
using UnityEngine;
using UnityEngine.UI;

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

        //Text boxes that update 
        private Text brandTextBox;
        private Text colourTextBox;
        private Text priceTextBox;
        private Text typeTextBox;
        
        
        //Filter variables
        private List<string> filterColours; //Get from FilterUI
        private List<string> filterBrandNames; //Get from FilterUI
        private List<string> filterType;

        private GameObject machineCountParent;
        private int clothingIndexValue;

        private void Start()
        {
            clothesMasterScriptObject = GameObject.Find("Environment");
            clothesMasterScript = clothesMasterScriptObject.GetComponent<ClothesMasterScript>();//Find ClothesMasterScript
            clothesMasterScript.GetLoadedClothes();

            filterScriptObject = GameObject.Find("UI/Canvas/FilterUI");
            filterUIScript = filterScriptObject.GetComponent<FilterUI>();

            machineCountParent = GameObject.Find("Models/ClothesMachines");
            clothingIndexValue = 0;

            brandTextBox = GameObject.Find("UI/Canvas/FilterUI/FilterViewPanel/FilterText/Brands/" +
                                           "BrandsTextListItem").GetComponent<Text>();
            
            colourTextBox = GameObject.Find("UI/Canvas/FilterUI/FilterViewPanel/FilterText/Colours/" +
                                           "ColoursTextListItem").GetComponent<Text>();
            
            typeTextBox = GameObject.Find("UI/Canvas/FilterUI/FilterViewPanel/FilterText/Types/" +
                                            "TypesTextListItem").GetComponent<Text>();
            
            priceTextBox = GameObject.Find("UI/Canvas/FilterUI/FilterViewPanel/FilterText/Prices/" +
                                            "PricesTextListItem").GetComponent<Text>();

        }
        private void GetFilterLists()
        {
            filterColours = filterUIScript.selectedColours;
            filterBrandNames = filterUIScript.selectedBrands;
            filterType = filterUIScript.selectedType;
        }
        public void Search()
        {
            Debug.Log("Search Clicked");
            GetFilterLists();
            FilterClothes();
            DisplayClothes();
        }
        private void FilterClothes(){
            clothesList = clothesMasterScript.GetLoadedClothes();
            foreach (var clothItem in clothesList)//Go through all loaded clothes,
            {
                if (clothItem.customColours.Any(cloth => filterColours.Any(colour => cloth == colour)))
                {
                    //Debug.Log("Added to filtered list: " + clothItem.name);;
                    if (!IsInList(clothItem))
                    {
                        filteredClothesList?.Add(clothItem);
                        DisplayFilterChoices(BuildUIString(filterUIScript.selectedColours), colourTextBox);
                        
                    }
                    else 
                    {
                        DisplayFilterChoices(BuildUIString(filterUIScript.selectedColours), colourTextBox);
                    }
                }
                else if (filterBrandNames.Any(brand => clothItem.brandName == brand))
                {
                    //Debug.Log("Added to filtered list: " + clothItem.name);;
                    if (!IsInList(clothItem))
                    {
                        filteredClothesList?.Add(clothItem);
                        DisplayFilterChoices(BuildUIString(filterUIScript.selectedBrands), brandTextBox);
                    }
                    else 
                    {
                        DisplayFilterChoices(BuildUIString(filterUIScript.selectedBrands), brandTextBox);
                    }

                }
                else if (filterType.Any(itemType => clothItem.itemType == itemType))
                {
                    //Debug.Log("Added to filtered list: " + clothItem.name);;
                    if (!IsInList(clothItem))
                    {
                        filteredClothesList?.Add(clothItem);
                        DisplayFilterChoices(BuildUIString(filterUIScript.selectedType), typeTextBox);
                    }
                    else
                    {
                        DisplayFilterChoices(BuildUIString(filterUIScript.selectedType), typeTextBox);
                    }

                }
                else if(clothItem.price.current.value >= filterUIScript.lowerPrice && clothItem.price.current.value <= 
                    filterUIScript.upperPrice)//Get two values and check if model price is between the two prices
                {
                    if (!IsInList(clothItem))
                    {
                        filteredClothesList?.Add(clothItem);
                        DisplayFilterChoices(BuildUIString(filterUIScript.selectedPrice), priceTextBox);
                    }
                }

                if (filteredClothesList == null) continue;
                /*foreach (var clothing in filteredClothesList)
                {
                    Debug.Log(clothing.name);
                }
                */
            }
        }
        
        private static string BuildUIString(IEnumerable<string> stringList)
        {
            return string.Join(", ", stringList);
        }
        private static void DisplayFilterChoices(string textValue, Text textObject)
        {
            Debug.Log("Text changed to " + textValue);
            textObject.text = textValue;
        }

        private bool IsInList(ClothingObject cloth)
        {
            return filteredClothesList.Contains(cloth);
        }
        private void Update()
        {
            GetFilterLists();
            
        }
        private int FindClothesMachines()
        {
            return machineCountParent.transform.childCount;
        }
        private static void SpawnClothingItem(int objectID, Component machineSpawnPoint)
        {
            var machineCloth = Resources.Load<GameObject>("Clothes/" + objectID); //Spawn into machine
            Instantiate(machineCloth, machineSpawnPoint.transform.position, Quaternion.identity);//Get correct scale and spawn point
        }
        private void DisplayClothes()
        {
            var clothesMachines = FindClothesMachines(); //get number of machines in hiarchy
            for (var i = 0; i < clothesMachines; i++)
            {
                if (clothingIndexValue >= clothesMachines)
                {
                    Debug.Log("Index is higher than machine count");
                    return;
                }
                var currentChild = machineCountParent.transform.GetChild(i); //get machine via index
                var machineSpawnPoint = currentChild.Find("spawnPoint");
                currentChild.GetComponent<ClothesMachine>().clothingObject 
                    = filteredClothesList[clothingIndexValue++]; //assign clothes equal to machine children
                SpawnClothingItem(currentChild.GetComponent<ClothesMachine>().clothingObject.id,
                    machineSpawnPoint);
            }
        }
    }
}