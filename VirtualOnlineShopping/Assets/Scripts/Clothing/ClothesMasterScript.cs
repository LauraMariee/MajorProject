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
        

        private void Start()
        {
            root = "Assets/AsosData/"; 
            filenames = ReadInCategories(); 
            foreach (var filename in filenames)
            {
                //Debug.Log(filename);
                ReadInJson(root + filename);
                
            }
        }
        private static List<string> ReadInCategories()
        {
            using (var r = new StreamReader("Assets/AsosData/categories.json"))// Read in json file
            {
                var json = r.ReadToEnd();
                var filenames = JsonConvert.DeserializeObject<List<string>>(json);// separate strings on file
                return filenames;
            }
        }
        private static void ReadInJson(string filename)
        {
            using (var r = new StreamReader(filename + ".json"))// Read in json file
            {
                var json = r.ReadToEnd();
                var items = JsonConvert.DeserializeObject<CategorySearchResult>(json);// separate strings on file
                var categoryString = items.categoryName;
                LoadedClothes.AddRange(AssignItemType(items, categoryString).products);
            }
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
            Debug.Log("Details Loaded for " + LoadedClothes.Count);
        }
        public List<ClothingObject> GetLoadedClothes()
        {
            return LoadedClothes;
        }
    }
}