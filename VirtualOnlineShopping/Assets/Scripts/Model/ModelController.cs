using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Model
{
    public class ModelController : MonoBehaviour
    {
        public Vector3 spawnPosition;
        
        public GameObject activeModel;
        public GameObject previousActiveModel; 

        public List<GameObject> buttons;
        
        public void Update()
        {
            previousActiveModel = activeModel;
            foreach (var button in buttons)
            {
                activeModel = button.GetComponent<SwitchModel>().GETActiveModel();
            }
            previousActiveModel.GetComponent<ModelInformation>().isActive = false;
        }

        public void MoveModel()
        {
            //DisplayCurrentModel();
            
            if (activeModel.GetComponent<FemaleModel>())
            {
                activeModel.GetComponent<Transform>().position =
                    new Vector3(spawnPosition.x, spawnPosition.y, spawnPosition.z); //Replace with vector3
            }
            else if (activeModel.GetComponent<MaleModel>())
            {
                activeModel.GetComponent<Transform>().position =
                    new Vector3(-10.89f, 4.39f, 7.71f); //Replace with vector3
            }
        }
        
        private void DisplayCurrentModel()
        {
            Debug.Log("Current active is " + activeModel + "and it is " + activeModel.GetComponent<ModelInformation>().isActive);
        }
        
        
        
    }
}