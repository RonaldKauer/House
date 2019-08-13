using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Going_to_Linvingroom : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Living_room_but")
        {
            SceneManager.LoadScene("Livingroom");
            // canvasObj2.SetActive(false);

        }
    }

    void OnMouseDown(){
        SceneManager.LoadScene("Livingroom");
    }

}
