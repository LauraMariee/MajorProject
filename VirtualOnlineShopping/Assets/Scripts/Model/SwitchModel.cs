using UnityEngine;
using Valve.VR;

namespace Model
{
    public class SwitchModel : MonoBehaviour
    {

        public Vector3 spawnPosition;
        public GameObject femaleModel;
        public GameObject maleModel;

        private static void RemoveModel()
        {
            var currentModel = GameObject.FindGameObjectWithTag("Model");
            Destroy(currentModel); 
        }

        public bool CheckLoadingSameModel(string newModelGender)
        {
            var currentModel = GameObject.FindGameObjectWithTag("Model");
            if(currentModel.GetComponent<ModelInformation>().gender == newModelGender)
            {
                return true;
            }
            return false;
        }

        public void SpawnModelFemale()
        {
            RemoveModel();
            Instantiate(femaleModel, spawnPosition, Quaternion.Euler(0, 0, 0));
        }

        public void SpawnModelMale()
        {
            RemoveModel();
            Instantiate(maleModel, new Vector3(-10.89f, 4.39f, 7.71f), Quaternion.Euler(0, 0, 0));
        }
    }
}
