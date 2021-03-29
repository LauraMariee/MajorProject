using System;
using UnityEngine;
using Valve.VR;

namespace Model
{
    public class SwitchModel : MonoBehaviour
    {
        public GameObject model;
        private bool clicked = false;


        public void OnButtonPressed()
        {
            Debug.Log("Clicked");
            clicked = true;
        }

        public bool HasButtonBeenPressed()
        {
            return clicked;
        }

        public void ResetButton()
        {
            clicked = false;
        }
        
        public GameObject GETModel()
        {
            return model;
        }
    }
}
