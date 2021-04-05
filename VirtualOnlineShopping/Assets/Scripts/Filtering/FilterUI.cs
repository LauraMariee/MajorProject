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
            return minPrice;//Get minprice
        }
        
        public float UpperRangeCheck()
        {
            const float maxPrice = 1;
            return maxPrice;//Get maxprice
        }
        
        public void ColourCLick()
        {
        }

        
        
        public void BrandCLick()
        {
        }
        
        private void Save()
        {
        
        }
    }
}
