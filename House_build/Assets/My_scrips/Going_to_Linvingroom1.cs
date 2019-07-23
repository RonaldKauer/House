using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
