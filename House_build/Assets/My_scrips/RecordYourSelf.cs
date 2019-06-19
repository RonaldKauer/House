using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class RecordYourSelf : MonoBehaviour
{

	public GameObject canvasObj;
    // Start is called before the first frame update
     // Get list of Microphone devices and print the names to the log
    public AudioSource testSound;
		// Material mat;
		

    void Start(){
			testSound = GetComponent<AudioSource>();
			canvasObj = transform.Find("Chair_Menu").gameObject as GameObject;
			canvasObj.SetActive(false);
		// 	MeshRenderer mesh = GetComponent<MeshRenderer>();
		//  	Material oldMaterial = mesh.material;
		// // testSound.Play();
    }


	void OnMouseDown(){
		testSound.Play();
		canvasObj.SetActive(true);
	}

	// void OnMouseEnter(){
	// 	mat = Resources.Load<Material>("Glow");
	// 	MeshRenderer mesh = GetComponent<MeshRenderer>();
	// 	Material oldMaterial = mesh.material;
	// 	mesh.materials[1] = mat;
	// }

	// void OnMouseExit(){
	// 	mesh.material = oldMaterial;
	// }


	public void CloseWindow(GameObject UIcanvas){
        UIcanvas.SetActive(false);
    }
}
