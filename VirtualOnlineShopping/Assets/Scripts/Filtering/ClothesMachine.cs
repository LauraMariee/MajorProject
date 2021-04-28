using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;
using Clothing;
using Model;
using UnityEngine;
using Timer = System.Timers.Timer;

namespace Filtering
{
    public class ClothesMachine : MonoBehaviour
    {
        public ClothingObject clothingObject{ get; set; }
        private ModelController modelController;

        private int topCount;
        private int bottomCount;
        private int middleCount;

        private readonly List<string> topStringCategories = new List<string>(){"Tops and Tanks", "Tops", "Hoodies & Sweatshirts"};
        private readonly List<string> bottomStringCategories = new List<string>(){"Jeans", "Loungewear"};
        private readonly List<string> middleStringCategories = new List<string>(){"Dresses"};

        private bool showModelErrorUI;
        private GameObject errorUI;

        // Start is called before the first frame update
        private void Start()
        {
            modelController = GameObject.Find("Environment/Base/CurrentModelController/").GetComponent<ModelController>();
            SetClothingCount();
            errorUI = GameObject.Find("UI/Canvas/NoActiveModelHint");
            showModelErrorUI = false; 
        }

        public void Update()
        {
            errorUI.SetActive(showModelErrorUI);
            //Debug.Log(showModelErrorUI);
        }
        
        private void DisplayErrorUI()
        {
            showModelErrorUI = true;
            var aTimer = new Timer {Interval = 5000, Enabled = true};
            aTimer.Elapsed+=(SetModelErrorUIFalse);
        }
        private void SetModelErrorUIFalse(object source, ElapsedEventArgs e)
        {
            showModelErrorUI = false;
            //Debug.Log("show error is " + showModelErrorUI);
        }
        
        
        private void ClothingDestroy(int count, IEnumerable<string> categoryStrings)
        {
            if (count < 1) return;
            var childCount = modelController.activeModel.transform.childCount;
            if (childCount <= 3) return;
            var currentChild = modelController.activeModel.transform.GetChild(4);

            if (!categoryStrings.Any(category =>
                currentChild.GetComponent<ClothingDetail>().itemType.Equals(category))) return;
            Destroy(currentChild); //destroy extra child
            Debug.Log(currentChild.name + " is destroyed");
        }
        private string SpawnLocationCheck()
        {
            if (topStringCategories.Any(category =>
                clothingObject.itemType.Equals(category))) return "Top";
            
            else if (bottomStringCategories.Any(category =>
                clothingObject.itemType.Equals(category))) return "Bottom";

            else if (middleStringCategories.Any(category =>
                clothingObject.itemType.Equals(category))) return "Middle";
            
            return "Location not set";
        }
        private void SpawnItemFromMachine(GameObject machineCloth, int count, Vector3 spawnPoint, IEnumerable<string> categories)
        {
            ClothingDestroy(count, categories);
            var clothes = Instantiate(machineCloth, spawnPoint,
                    Quaternion.Euler(0, 90, 0));
            clothes.transform.SetParent(modelController.activeModel.transform);
            Debug.Log("Spawned " + machineCloth.name);
            count++;
        }
        public void SpawnItemOnModel()
        {
            modelController.activeModel = GetActiveModel();
            var machineCloth = Resources.Load<GameObject>("Clothes/" + clothingObject.id); //Spawn into machine

            switch (SpawnLocationCheck())
            {
                case "Top":
                    try
                    {
                        SpawnItemFromMachine(machineCloth, topCount,
                        modelController.activeModel.GetComponent<BaseModel>().topSpawn.position,
                        topStringCategories);
                    }
                    catch (Exception ex)
                    { 
                        DisplayErrorUI();
                        Debug.Log(ex);
                    }
                    
                    break;
                case "Middle":
                    try
                    {
                        SpawnItemFromMachine(machineCloth, middleCount,
                        modelController.activeModel.GetComponent<BaseModel>().middleSpawn.position,
                        middleStringCategories);
                    }
                    catch (Exception ex)
                    { 
                        DisplayErrorUI();
                        Debug.Log(ex);
                    }
                    break;
                case "Bottom":
                    try
                    {
                        SpawnItemFromMachine(machineCloth, bottomCount,
                        modelController.activeModel.GetComponent<BaseModel>().bottomSpawn.position,
                        bottomStringCategories);
                    }
                    catch (Exception ex)
                    { 
                        DisplayErrorUI();
                        Debug.Log(ex);
                    }
                    break;
                case"Location not set":
                    //Debug.Log("Location not set for " + machineCloth.name);
                    break;
                default:
                    break;
            }
        }
        
        
        private GameObject GetActiveModel()
        {
            return modelController.activeModel;
        }
        private void SetClothingCount()
        {
            topCount = 0;
            middleCount = 0;
            bottomCount = 0; 
        }
        
        
    }
}
