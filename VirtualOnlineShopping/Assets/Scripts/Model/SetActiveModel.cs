using UnityEngine;

namespace Model
{
    public class SetActiveModel : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            var modelObject = other.gameObject;
            Debug.Log(modelObject + " Entered");
            
            //if (!modelObject.tag.Equals("Model")) return;

            if (!(modelObject.GetComponentInParent(typeof(BaseModel)) as BaseModel)) return;
            Debug.Log("Model is enabled");
            modelObject.GetComponentInParent<BaseModel>().enabled = true;

        }

        private void OnTriggerExit(Collider other)
        {
            var modelObject = other.gameObject;
            Debug.Log(other + " Exited");
            
            //if (!other.gameObject.tag.Equals("Model")) return;

            if (!(modelObject.GetComponentInParent(typeof(BaseModel)) as BaseModel)) return;
            Debug.Log("Model is disabled");
            modelObject.GetComponentInParent<BaseModel>().enabled = false;
        }
    }
}
