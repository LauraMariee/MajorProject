using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Model
{
    public class ModelController : MonoBehaviour
    {

        public List<GameObject> models;
        public Vector3 spawnPosition;
        
        
        public void MoveModel()
        {
            foreach (var model in models.Where(model => model.GetComponent<ModelInformation>().isActive))
            {
                if (model.GetComponent<FemaleModel>())
                {
                    model.GetComponent<Transform>().position =
                        new Vector3(spawnPosition.x, spawnPosition.y, spawnPosition.z);
                }
                else if (model.GetComponent<MaleModel>())
                {
                    model.GetComponent<Transform>().position =
                        new Vector3(-10.89f, 4.39f, 7.71f);
                }

            }
        }
    }
}
