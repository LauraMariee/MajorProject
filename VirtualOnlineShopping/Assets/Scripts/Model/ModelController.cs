using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    public class ModelController : MonoBehaviour
    {
        private Vector3 spawnPosition;
        
        public GameObject activeModel; //find models in hierarchy
        private Vector3 activeModelOrigin;
        
        public List<GameObject> switchModelButtons;

        public void Start()
        {
            var spawnPositionObject = GameObject.Find("PodiumPosition");
            spawnPosition = spawnPositionObject.GetComponent<Transform>().position;
        }

        public void Update()
        {
            foreach (var button in switchModelButtons)
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

        private void MoveModel(GameObject previousActive, GameObject newActive)
        {
            // move old active model back to where it was 
            if (previousActive != null)
            {
                previousActive.GetComponent<Transform>().position = activeModelOrigin;
            }

            // move active model into spotlight
            if (newActive == null) return;
            // remember where it came from so that we can move it back there
            activeModelOrigin = newActive.GetComponent<Transform>().position;

            // WE WANT TO MOVE IT, MOVE IT! MOVE IT!
            newActive.GetComponent<Transform>().position = spawnPosition;
        }
    }
}