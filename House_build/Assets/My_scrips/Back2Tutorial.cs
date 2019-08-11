using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Back2Tutorial : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Tutorial")
        {
            SceneManager.LoadScene("Tutorial");
            // canvasObj2.SetActive(false);

        }
    } 
}
