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
        
            if(modelObject.GetComponentInParent(typeof(MaleModel)) as MaleModel)
            {
                Debug.Log("Male is enabled");
                modelObject.GetComponentInParent<MaleModel>().enabled = true; 
            }
            if(modelObject.GetComponentInParent(typeof(FemaleModel)) as FemaleModel)
            {
                Debug.Log("Female is enabled");
                modelObject.GetComponentInParent<FemaleModel>().enabled = false; 
            }
        }

        private void OnTriggerExit(Collider other)
        {
            Debug.Log(other + " Exited");
            
            //if (!other.gameObject.tag.Equals("Model")) return;
        
            if(other.gameObject.GetComponentInParent(typeof(MaleModel)) as MaleModel)
            {
                Debug.Log("Male is disabled");
                other.gameObject.GetComponentInParent<MaleModel>().enabled = false; 
            }
            if(other.gameObject.GetComponentInParent(typeof(FemaleModel)) as FemaleModel)
            {
                Debug.Log("Female is disabled");
                other.gameObject.GetComponentInParent<FemaleModel>().enabled = false; 
            }
        }
    }
}
