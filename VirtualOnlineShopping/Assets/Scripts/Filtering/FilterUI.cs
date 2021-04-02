using UnityEngine;
using UnityEngine.UI;

namespace Filtering
{
    public class FilterUI : MonoBehaviour
    {
        private string colour;
        private string brandName;


        // Start is called before the first frame update
        void Start()
        {
        
        }

        public void ColourCLick()
        {
            DetailMenuCheck(); //Check if detail menu open 
            //replace buttons if yes
            //Show Detail menu if no
            //save singular option 
        }

        private static bool DetailMenuCheck()
        {
            var detailPanel = GameObject.Find("UI/Canvas/FilterUI/detailsMenu");
            if(detailPanel)
            //find detail model check
            //if detail model is active return true
            //if detail model is not active then return false
        }
        
        public void BrandCLick()
        {
            //Check if detail menu open 
            //replace buttons if yes
            //Show Detail menu if no
        }
        
        private void Save()
        {
        
        }
        

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
