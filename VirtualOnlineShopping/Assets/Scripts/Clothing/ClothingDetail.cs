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


        private bool isTriggered{get; set;}
        
        private GameObject clothingDetailPanel;

        private void Start()
        {
            clothingDetailPanel = GameObject.Find("UI/Canvas/ClothesDetailPanel");
            isTriggered = false;
        }

        public void OnTriggerEnter(Collider other)
        {
            clothingDetailPanel.SetActive(true);
            isTriggered = true;
        }
        
        public void OnTriggerExit(Collider other)
        {
            isTriggered = true;
            clothingDetailPanel.SetActive(false);
        }

        public void Update()
        {
            Debug.Log("Item name is " + itemName);
        }

        public bool IsTriggered()
        {
            return isTriggered;
        }

    }
    
}