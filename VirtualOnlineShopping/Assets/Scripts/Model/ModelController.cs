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

        public List<GameObject> buttons;
        
        public void Update()
        {
            foreach (var button in buttons)
            {
                activeModel = button.GetComponent<SwitchModel>().GETActiveModel();
                Debug.Log(activeModel);
            }
        }

        public void MoveModel()
        {
            if (activeModel.GetComponent<FemaleModel>())
            {
                activeModel.GetComponent<Transform>().position =
                    new Vector3(spawnPosition.x, spawnPosition.y, spawnPosition.z);
            }
            else if (activeModel.GetComponent<MaleModel>())
            {
                activeModel.GetComponent<Transform>().position =
                    new Vector3(-10.89f, 4.39f, 7.71f);
            }
        }
    }
}