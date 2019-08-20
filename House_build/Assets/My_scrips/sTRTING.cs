using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sTRTING : MonoBehaviour
{
    // Start is called before the first frame update
   void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene("house_build");
            // canvasObj2.SetActive(false);

        }
    }
}
