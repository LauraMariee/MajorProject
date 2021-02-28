using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Valve.Newtonsoft.Json;

namespace Clothing
{
    public class ClothesMasterScript : MonoBehaviour
    {

        private readonly List<string> filenames = new List<string>()
            {"18797", "11321", "8799", "7616", "5668", "4208", "4169", "3630"};

        private static readonly List<ClothingObject> LoadedClothes = new List<ClothingObject>();
        
        
        // Start is called before the first frame update
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

            ShowListData(); 
        }

        private static void ShowListData()
        {
            foreach (var item in LoadedClothes)
            {
                Debug.Log(item.name + " : " + item.colour);
            }
        }
        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
