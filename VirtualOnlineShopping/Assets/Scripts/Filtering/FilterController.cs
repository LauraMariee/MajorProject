using System;
using System.Collections.Generic;
using System.Linq;
using Clothing;
using UnityEngine;
using UnityEngine.UI;
using Object = System.Object;

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
            
            clothingIndexValue = filterUIScript.intIndex;
        }
        private void GetFilterLists()
        {
            filterColours = filterUIScript.selectedColours;
            filterBrandNames = filterUIScript.selectedBrands;
            filterType = filterUIScript.selectedType;
        }
        private void GetIndexValue()
        {
            clothingIndexValue = filterUIScript.intIndex;
        }
        private void SetIndexValue(int newValue)
        {
            filterUIScript.intIndex = newValue;
        }
        public void Search()
        {
            Debug.Log("Search Clicked");
            GetFilterLists();
            FilterClothes();
            DisplayClothes();
        }
        public void Next(){
            Debug.Log("Next Clicked");
            GetIndexValue();
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
                    }
                }
                else if (filterBrandNames.Any(brand => clothItem.brandName == brand))
                {
                    //Debug.Log("Added to filtered list: " + clothItem.name);;
                    if (!IsInList(clothItem))
                    {
                        filteredClothesList?.Add(clothItem);
                        
                    }
                }
                else if (filterType.Any(itemType => clothItem.itemType == itemType))
                {
                    //Debug.Log("Added to filtered list: " + clothItem.name);;
                    if (!IsInList(clothItem))
                    {
                        filteredClothesList?.Add(clothItem);
                        
                    }
                }
                else if(clothItem.price.current.value >= filterUIScript.lowerPrice && clothItem.price.current.value <= 
                    filterUIScript.upperPrice)//Get two values and check if model price is between the two prices
                {
                    if (!IsInList(clothItem))
                    {
                        filteredClothesList?.Add(clothItem);
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
        private bool IsInList(ClothingObject cloth)
        {
            return filteredClothesList.Contains(cloth);
        }
        private void Update()
        {
            GetFilterLists();
            GetIndexValue();
        }
        private int FindClothesMachines()
        {
            return machineCountParent.transform.childCount;
        }
        private static void SpawnClothingItem(int objectID, Component machineSpawnPoint, Transform machine)
        {
            var machineCloth = Resources.Load<GameObject>("Clothes/" + objectID); //Spawn into machine
            var clothingObject =Instantiate(machineCloth, machineSpawnPoint.transform.position, Quaternion.identity).transform.parent = machine;//Get correct scale and spawn point and spawn as machine child
            clothingObject.transform.localScale = new Vector3(1, 1, 1); // change its local scale in x y z format
            Debug.Log("Scale is " + clothingObject.transform.localScale);
        }
        private void DisplayClothes()
        {
            var clothesMachines = FindClothesMachines(); //get number of machines in hiarchy
            for (var i = 0; i < clothesMachines; i++)
            {
                Debug.Log("ClothingIndexValue is " + clothingIndexValue + " , Total in list is " + filteredClothesList.Count);
                
                var currentChild = machineCountParent.transform.GetChild(i); //get machine via index
                var machineSpawnPoint = currentChild.Find("spawnPoint");

                if (clothingIndexValue >= filteredClothesList.Count)
                {
                    SetIndexValue(clothingIndexValue = 0);
                }
                
                try
                {
                    currentChild.GetComponent<ClothesMachine>().clothingObject 
                    = filteredClothesList[clothingIndexValue++]; //assign clothes equal to machine children
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine(e);
                    throw;
                }

                var childCount = currentChild.transform.childCount; //check if it has more than 4 children
                if (childCount > 4)
                {
                    Destroy(currentChild.transform.GetChild(4).gameObject); //destroy extra child
                }
                
                SpawnClothingItem(currentChild.GetComponent<ClothesMachine>().clothingObject.id,
                    machineSpawnPoint, currentChild);
                
            }
        }
    }
}