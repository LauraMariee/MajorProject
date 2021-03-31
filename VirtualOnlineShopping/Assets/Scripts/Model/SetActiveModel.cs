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

            if (!(modelObject.GetComponentInParent(typeof(AbstractModel)) as AbstractModel)) return;
            Debug.Log("Model is enabled");
            modelObject.GetComponentInParent<AbstractModel>().enabled = true;

        }

        private void OnTriggerExit(Collider other)
        {
            var modelObject = other.gameObject;
            Debug.Log(other + " Exited");
            
            //if (!other.gameObject.tag.Equals("Model")) return;

            if (!(modelObject.GetComponentInParent(typeof(AbstractModel)) as AbstractModel)) return;
            Debug.Log("Model is disabled");
            modelObject.GetComponentInParent<AbstractModel>().enabled = false;
        }
    }
}
