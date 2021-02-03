using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchModel : MonoBehaviour
{

    public Vector3 spawnPosition;
    public GameObject model;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void removeModel()
    {
        GameObject currentModel = GameObject.FindGameObjectWithTag("Model");
        Destroy(currentModel); 
    }

    //public bool checkLoadingSameModel(string newModelGender)
    //{
    //    GameObject currentModel = GameObject.FindGameObjectWithTag("Model");
    //    if(currentModel.GetComponent<ModelInformation>().gender == newModelGender)
    //    {
    //        return true;
    //    }
    //  return false;
    //}

    public void spawnModel()
    {
        //if (!checkCurrentModel("Female"))
        //{
            removeModel();
            Instantiate(model, spawnPosition, Quaternion.Euler(0, 0, 0));
        //}
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            spawnModel();
        }

    }
}
