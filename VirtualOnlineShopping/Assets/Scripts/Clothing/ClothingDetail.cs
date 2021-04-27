using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.UI;

namespace Clothing
{
    public class ClothingDetail : MonoBehaviour
    {
        public int id { get; set; } 
        public string itemName{get; set;}
        public float price{get; set;}
        public string brandName{get; set;}
        public int productCode{get; set;}
        public string url{get; set;}
        public string imageUrl{get; set;}
        public string itemType{get; set;}
        public List<string> customColours{get; set;}
        
        private GameObject clothingDetailPanel;

        private void Start()
        {
            clothingDetailPanel = GameObject.Find("UI/Canvas/ClothesDetailPanel");
        }

        public void OnTriggerEnter(Collider other)
        {
            clothingDetailPanel.SetActive(true);
            //Debug.Log("Panel Assigned");
            ShowDetailUI();
        }
        public void OnTriggerExit(Collider other)
        {
            clothingDetailPanel.SetActive(false);
        }
        
        private static string BuildUIString(IEnumerable<string> stringList)
        {
            return string.Join(", ", stringList);
        }
        private void ShowDetailUI()
        {
            var numberOfFields = clothingDetailPanel.transform.childCount; 
            for(var i = 0; i <= numberOfFields; i++)
            {
                var clothingItem = clothingDetailPanel.transform.GetChild(i).gameObject;
                var field = clothingDetailPanel.transform.GetChild(i).GetComponent<Text>();
                
                switch (clothingItem.name)
                {
                    case "itemName":
                        field.text = itemName;
                        Debug.Log(itemName);
                        break;
                    case "price":
                        field.text = price.ToString();
                        Debug.Log(price.ToString());
                        break;
                    case "brandName":
                        field.text = brandName;
                        Debug.Log(brandName);
                        break;
                    case "colour":
                        field.text = BuildUIString(customColours);
                        Debug.Log(BuildUIString(customColours));
                        break;
                    default:
                        break;
                }
                
            }
        }
    }
    
}