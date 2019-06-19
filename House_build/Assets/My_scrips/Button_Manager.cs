using System.Collections;
using UnityEngine;

public class Button_Manager : MonoBehaviour
{
    public void CloseWindow(GameObject UIcanvas){
        UIcanvas.SetActive(false);
    }
}
