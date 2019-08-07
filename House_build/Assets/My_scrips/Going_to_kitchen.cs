using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Going_to_kitchen : MonoBehaviour
{
void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Kitchen_but")
        {
            SceneManager.LoadScene("KitchenDining");
            // canvasObj2.SetActive(false);

        }
    }
}
