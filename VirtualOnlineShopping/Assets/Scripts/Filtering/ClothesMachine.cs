using System.Collections.Generic;
using System.Linq;
using Clothing;
using Model;
using UnityEngine;

namespace Filtering
{
    public class ClothesMachine : MonoBehaviour
    {
        public ClothingObject clothingObject{ get; set; }
        private ModelController modelController;

        private GameObject activeModel;

        private int topCount;
        private int bottomCount;
        private int middleCount;

        private readonly List<string> topStringCategories = new List<string>(){"Tops and Tanks", "Tops", "Hoodies and Sweatshirts"};
        private readonly List<string> bottomStringCategories = new List<string>(){"Jeans", "Loungewear"};
        private readonly List<string> middleStringCategories = new List<string>(){"Dresses"};

        // Start is called before the first frame update
        private void Start()
        {
            modelController = GameObject.Find("Environment/Base/CurrentModelController/").GetComponent<ModelController>();
            activeModel = GetActiveModel();
            SetClothingCount();
        }
        public void SpawnItemOnModel()
        {
            activeModel = GetActiveModel();
            var machineCloth = Resources.Load<GameObject>("Clothes/" + clothingObject.id); //Spawn into machine

            switch (SpawnLocationCheck())
            {
                case "Top":
                    ClothingDestroy(topCount, topStringCategories);
                    SpawnItem(modelController.activeModel.GetComponent<AbstractModel>().topSpawn.position, machineCloth);
                    Debug.Log("Spawned " + machineCloth.name);
                    topCount++;
                    break;
                case "Middle":
                    ClothingDestroy(middleCount, middleStringCategories);
                    SpawnItem(modelController.activeModel.GetComponent<AbstractModel>().middleSpawn.position, machineCloth);
                    Debug.Log("Spawned " + machineCloth.name);
                    middleCount++;
                    break;
                case "Bottom":
                    ClothingDestroy(bottomCount, bottomStringCategories);
                    SpawnItem(modelController.activeModel.GetComponent<AbstractModel>().bottomSpawn.position, machineCloth);
                    Debug.Log("Spawned " + machineCloth.name);
                    bottomCount++;
                    break;
                case"Location not set":
                    Debug.Log("Location not set for " + machineCloth.name);
                    break;
                default:
                    break;
            }
        }

        private void SpawnItem(Vector3 position, GameObject clothing)
        {
            var clothes = Instantiate(clothing, position,
                Quaternion.Euler(0, 90, 0));
            clothes.transform.SetParent(activeModel.transform);
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
        
        private void ClothingDestroy(int count, IEnumerable<string> categoryStrings)
        {
            if (count < 1) return;
            var childCount = activeModel.transform.childCount;
            if (childCount <= 3) return;
            var currentChild = activeModel.transform.GetChild(4);

            if (!categoryStrings.Any(category =>
                currentChild.GetComponent<ClothingDetail>().itemType.Equals(category))) return;
            Destroy(currentChild); //destroy extra child
            Debug.Log(currentChild.name + " is destroyed");
        }
        
    }
}
