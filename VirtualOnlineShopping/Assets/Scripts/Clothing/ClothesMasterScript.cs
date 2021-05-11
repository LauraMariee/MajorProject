using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using Valve.Newtonsoft.Json;


namespace Clothing
{
    public class ClothesMasterScript : MonoBehaviour
    {

        private List<string> filenames = new List<string>();
        private string root; 

        public static readonly List<ClothingObject> LoadedClothes = new List<ClothingObject>();
        
        private GameObject clothingDetailPanel;

        private void Start()
        {
            filenames = ReadInCategories(); 
            foreach (var filename in filenames)
            {
                //Debug.Log(filename);
                ReadInJson(filename);
                
            }
            clothingDetailPanel = GameObject.Find("UI/Canvas/ClothesDetailPanel");
        }
        private static List<string> ReadInCategories()
        {
            var filepath = Resources.Load<TextAsset>("AsosData/categories");
            var filenames = JsonConvert.DeserializeObject<List<string>>(filepath.text);// separate strings on file
            return filenames;
        }
        private static void ReadInJson(string filename)
        {
            var file = Resources.Load<TextAsset>("AsosData/" + filename);
            var items = JsonConvert.DeserializeObject<CategorySearchResult>(file.text);// separate strings on file
            var categoryString = items.categoryName;
            LoadedClothes.AddRange(AssignItemType(items, categoryString).products);
            AssignToGameObjects();
        }
        private static CategorySearchResult AssignItemType(CategorySearchResult items, string category)
        {
            foreach (var clothes in items.products)
            {
                clothes.itemType = category; 
            }

            return items;
        }
        private static void AssignToGameObjects()
        {
            foreach (var loadedCloth in LoadedClothes)
            {
                if (!(Resources.Load("Clothes/" + loadedCloth.id, typeof(GameObject)) is GameObject foundClothes))
                    continue;
                
                var clothingDetailObject = foundClothes.GetComponent<ClothingDetail>();
                
                clothingDetailObject.id = loadedCloth.id;
                clothingDetailObject.itemName = loadedCloth.name;
                clothingDetailObject.price = loadedCloth.price.current.value;
                clothingDetailObject.brandName = loadedCloth.brandName;
                clothingDetailObject.productCode = loadedCloth.productCode;
                clothingDetailObject.url = loadedCloth.url;
                clothingDetailObject.imageUrl = loadedCloth.imageUrl;
                clothingDetailObject.itemType = loadedCloth.itemType;
                
                clothingDetailObject.customColours = loadedCloth.customColours;
                
            }
        }
        public List<ClothingObject> GetLoadedClothes()
        {
            return LoadedClothes;
        }
        private void ShowDetailUI(ClothingDetail clothes)
        {
            var numberOfFields = clothingDetailPanel.transform.childCount; 
            for(var i = 0; i <= numberOfFields; i++)
            {
                var clothingItem = clothingDetailPanel.transform.GetChild(i).gameObject;
                var field = clothingDetailPanel.transform.GetChild(i).GetComponent<Text>();
                
                switch (clothingItem.name)
                {
                    case "itemName":
                        field.text = clothes.itemName;
                        Debug.Log(clothes.itemName);
                        break;
                    case "price":
                        field.text = clothes.price.ToString();
                        Debug.Log(clothes.price.ToString());
                        break;
                    case "brandName":
                        field.text = clothes.brandName;
                        Debug.Log(clothes.brandName);
                        break;
                    case "colour":
                        field.text = BuildUIString(clothes.customColours);
                        Debug.Log(BuildUIString(clothes.customColours));
                        break;
                    default:
                        break;
                }
                
            }
        }
        private static string BuildUIString(IEnumerable<string> stringList)
        {
            return string.Join(", ", stringList);
        }

        public void Update()
        {
            
        }
    }
}