using UnityEngine;

namespace Model
{
    public class ModelController : MonoBehaviour
    {
        public GameObject activeBody;
        public GameObject inActiveBody; 
        
        // Start is called before the first frame update
        void Start()
        {
        
        }

        public void MoveModel()
        {
            //Move model from back spot to front spot
            activeBody.GetComponent<Transform>().position = new Vector3(0, 0, 0);
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
