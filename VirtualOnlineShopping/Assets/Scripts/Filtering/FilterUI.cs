using UnityEngine;
using UnityEngine.UI;

namespace Filtering
{
    public class FilterUI : MonoBehaviour
    {
        private string colour;
        private string brandName;
        private int price;


        // Start is called before the first frame update
        void Start()
        {
        
        }

        public float LowerRangeCheck()
        {
            const float minPrice = 0;
            DetailMenuCheck(); //Check if detail menu open
            return minPrice;//Get minprice
        }
        
        public float UpperRangeCheck()
        {
            const float maxPrice = 1;
            DetailMenuCheck(); //Check if detail menu open
            return maxPrice;//Get maxprice
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
            return true;
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
