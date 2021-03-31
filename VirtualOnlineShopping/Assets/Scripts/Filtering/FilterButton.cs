using UnityEngine;
using UnityEngine.UI;

namespace Filtering
{
    public class FilterButton : MonoBehaviour
    {
        public Button button;
        private bool clicked; 
    
        // Start is called before the first frame update
        void Start()
        {
        
        }

        public void OnClick()
        {
            clicked = true; 
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
