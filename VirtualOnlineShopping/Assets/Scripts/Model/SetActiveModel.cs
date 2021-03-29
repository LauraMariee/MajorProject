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
                modelObject.GetComponentInParent<FemaleModel>().enabled = true; 
            }
        }

        private void OnTriggerExit(Collider other)
        {
            var modelObject = other.gameObject;
            Debug.Log(other + " Exited");
            
            //if (!other.gameObject.tag.Equals("Model")) return;
        
            if(modelObject.GetComponentInParent(typeof(MaleModel)) as MaleModel)
            {
                Debug.Log("Male is disabled");
                modelObject.GetComponentInParent<MaleModel>().enabled = false; 
            }
            if(modelObject.GetComponentInParent(typeof(FemaleModel)) as FemaleModel)
            {
                Debug.Log("Female is disabled");
                modelObject.GetComponentInParent<FemaleModel>().enabled = false; 
            }
        }
    }
}
