using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Going_to_Bedroom : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bedroom_but")
        {
            SceneManager.LoadScene("Bedroom");
            // canvasObj2.SetActive(false);

        }
    }

}

