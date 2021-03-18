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
                if (!switchButton.HasButtonBeenPressed()) continue;
                var oldActive = activeModel;
                activeModel = switchButton.GETModel();
                switchButton.ResetButton();
                // ReSharper disable once Unity.PerformanceCriticalCodeInvocation
                MoveModel(oldActive, activeModel);
            }
        }

        public void MoveModel(GameObject previousActive, GameObject newActive)
        {
            // move old active model back to where it was 
            if (previousActive != null)
            {
                previousActive.GetComponent<Transform>().position = activeModelOrigin;
                /*switch (CheckModelGender())
                {
                    case "FemaleModel":
                        previousActive.GetComponent<FemaleModel>().enabled = false;
                        break;
                    case "MaleModel":
                        previousActive.GetComponent<MaleModel>().enabled = false;
                        break;
              } */ 
            }

            // move active model into spotlight
            if (newActive == null) return;
            // remember where it came from so that we can move it back there
            activeModelOrigin = newActive.GetComponent<Transform>().position;

            // WE WANT TO MOVE IT, MOVE IT! MOVE IT!
            newActive.GetComponent<Transform>().position = spawnPosition;
            
/*switch (CheckModelGender())
{
    case "FemaleModel":
        activeModel.GetComponent<FemaleModel>().enabled = true;
        break;
    case "MaleModel":
        activeModel.GetComponent<MaleModel>().enabled = true;
        break;
}*/
}

private string CheckModelGender()
{
if(activeModel.GetComponent<FemaleModel>())
{
    return "FemaleModel"; 
}
return activeModel.GetComponent<MaleModel>() ? "MaleModel" : "Blank";
}
}
}