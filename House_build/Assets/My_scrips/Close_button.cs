using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Close_button : MonoBehaviour
{
 
    public GameObject canvasObj;
    // public GameObject canvasObj2;
 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Close_button")
        {
            canvasObj.SetActive(false);
            // canvasObj2.SetActive(false);

        }
    }

}
