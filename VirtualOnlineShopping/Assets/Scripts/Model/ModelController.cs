using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Model
{
    public class ModelController : MonoBehaviour
    {
        private Vector3 spawnPosition;
        
        public GameObject activeModel;
        private Vector3 activeModelOrigin;
        
        public List<GameObject> buttons;


        public void Start()
        {
            var spawnPositionObject = GameObject.Find("PodiumPosition");
            spawnPosition = spawnPositionObject.GetComponent<Transform>().position; 
        }

        public void Update()
        {
            foreach (var button in buttons)
            {
                var switchButton = button.GetComponent<SwitchModel>();
                if (switchButton.HasButtonBeenPressed())
                {
                    var oldActive = activeModel;
                    activeModel = switchButton.GETModel();
                    switchButton.ResetButton();
                    // ReSharper disable once Unity.PerformanceCriticalCodeInvocation
                    MoveModel(oldActive, activeModel);
                }
            }
        }

        public void MoveModel(GameObject previousActive, GameObject newActive)
        {
            // move old active model back to where it was 
            if (previousActive != null)
            {
                previousActive.GetComponent<Transform>().position = activeModelOrigin;
            }

            // move active model into spotlight
            if (newActive != null)
            {
                // remember where it came from so that we can move it back there
                activeModelOrigin = newActive.GetComponent<Transform>().position;
                
                // WE WANT TO MOVE IT, MOVE IT! MOVE IT!
                if (newActive.GetComponent<FemaleModel>())
                {
                    newActive.GetComponent<Transform>().localPosition = spawnPosition; //Replace with vector3
                }
                else if (newActive.GetComponent<MaleModel>())
                {
                    newActive.GetComponent<Transform>().localPosition = spawnPosition; //Replace with vector3
                    //newActive.GetComponent<Transform>().position = new Vector3(-10.89f, 4.39f, 7.71f); //Replace with vector3
                }
            }
            //DisplayCurrentModel();
            
            
        }
    }
}