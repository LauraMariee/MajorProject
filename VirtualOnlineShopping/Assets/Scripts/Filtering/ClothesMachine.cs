using System.Runtime.CompilerServices;
using Clothing;
using Model;
using UnityEngine;
using UnityEngine.UI;

namespace Filtering
{
    public class ClothesMachine : MonoBehaviour
    {
        public ClothingObject clothingObject{ get; set; }
        
        //find UI buttons and assign on start
        private Button spawnButton;
        private Button smallSizeButton;
        private Button mediumSizeButton;
        private Button largeSizeButton;

        private ModelController modelController;

        // Start is called before the first frame update
        private void Start()
        {
            modelController = GameObject.Find("Environment/Base/CurrentModelController").GetComponent<ModelController>();
            AssignMachineButtons(GetMachineName());
        }
        private string GetMachineName()
        {
            return this.gameObject.name; //Get machine name
        }
        private void AssignMachineButtons(string machineName)
        {
            spawnButton = GameObject.Find("UI/Canvas/ClothesHolderButtons/" + machineName + "/SpawnButton").GetComponent<Button>();
            smallSizeButton = GameObject.Find("UI/Canvas/ClothesHolderButtons/" + machineName + "/SmallButton").GetComponent<Button>();
            mediumSizeButton = GameObject.Find("UI/Canvas/ClothesHolderButtons/" + machineName + "/MediumButton").GetComponent<Button>();
            largeSizeButton = GameObject.Find("UI/Canvas/ClothesHolderButtons/" + machineName + "/LargeButton").GetComponent<Button>();
        }
        public void SpawnItemOnModel()
        {
            var machineCloth = Resources.Load<GameObject>("Clothes/" + clothingObject.id); //Spawn into machine
            
            if(SpawnLocationCheck().Equals("Top"))
            {
                Debug.Log("Spawned Top Item at " + modelController.activeModel.GetComponent<AbstractModel>().topSpawn);
                Instantiate(machineCloth, modelController.activeModel.GetComponent<AbstractModel>().topSpawn.localPosition,
                                Quaternion.Euler(0, 90, 0));
            }
            if(SpawnLocationCheck().Equals("Bottom"))
            {
                Debug.Log("Spawned Bottom Item at " + modelController.activeModel.GetComponent<AbstractModel>().bottomSpawn);
                Instantiate(machineCloth, modelController.activeModel.GetComponent<AbstractModel>().bottomSpawn.localPosition,
                    Quaternion.Euler(0, 90,0));
            }
            if(SpawnLocationCheck().Equals("Dress"))
            {
                Debug.Log("Spawned Dress Item at " + modelController.activeModel.GetComponent<AbstractModel>().middleSpawn);
                Instantiate(machineCloth, modelController.activeModel.GetComponent<AbstractModel>().middleSpawn.localPosition,
                    Quaternion.Euler(0, 90,0));
            }
        }

        private string SpawnLocationCheck()
        {
            switch (clothingObject.itemType)
            {
                case "Jeans":
                    return "Bottom";
                case "Loungewear":
                    return "Bottom";
                case "Tops":
                    return "Top";
                case "Hoodies & Sweatshirts":
                    return "Top";
                case "T-Shirts & Tanks":
                    return "Top";
                case "Dresses":
                    return "Dress";
                default:
                    return "";
            }
        }
    }
}
