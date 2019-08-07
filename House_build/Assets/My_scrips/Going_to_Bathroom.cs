using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Going_to_Bathroom : MonoBehaviour
{

void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bathroom_but")
        {
            SceneManager.LoadScene("Bathroom");
            // canvasObj2.SetActive(false);

        }
    }

}
