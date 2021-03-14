using System;
using UnityEngine;
using Valve.VR;

namespace Model
{
    public class SwitchModel : MonoBehaviour
    {
        public GameObject model;

        public void OnMouseClicked()
        {
            Debug.Log("Clicked");
            model.GetComponent<ModelInformation>().isActive = true;
            GETActiveModel();
        }

        public GameObject GETActiveModel()
        {
            return model;
        }
    }
}
