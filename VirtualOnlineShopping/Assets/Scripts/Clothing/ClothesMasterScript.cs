using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using Valve.Newtonsoft.Json;

namespace Clothing
{
    public class ClothesMasterScript : MonoBehaviour
    {

        private readonly List<string> filenames = new List<string>()
            {"18797", "11321", "8799", "7616", "5668", "4208", "4169", "3630"};

        public static List<GameObject> clothingGameObjects = new List<GameObject>(); 
        private static readonly List<ClothingObject> LoadedClothes = new List<ClothingObject>();

        private void Start()
        {
            foreach (var filename in filenames)
            {
                ReadInJson(filename);
            }
        }
        private static void ReadInJson(string filename)
        {
            using (var r = new StreamReader(filename + ".json"))// Read in json file
            {
                var json = r.ReadToEnd();
                var items = JsonConvert.DeserializeObject<CategorySearchResult>(json);// separate strings on file
                if (items == null)
                {
                    // todo some error handling
                    Debug.Log( "Error");
                }
                else
                {
                    LoadedClothes.AddRange(items.products);
                }
            }
            AssignToGameObjects();
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
                clothingDetailObject.colour = loadedCloth.colour;
                clothingDetailObject.brandName = loadedCloth.brandName;
                clothingDetailObject.productCode = loadedCloth.productCode;
                clothingDetailObject.url = loadedCloth.url;
                clothingDetailObject.imageUrl = loadedCloth.imageUrl;
            }
        }
    }
}
