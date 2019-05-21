using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class RecordYourSelf : MonoBehaviour
{
    // Start is called before the first frame update
     // Get list of Microphone devices and print the names to the log
    public AudioSource testSound;
		// Material mat;
		

    void Start(){
			testSound = GetComponent<AudioSource>();
		// 	MeshRenderer mesh = GetComponent<MeshRenderer>();
		//  	Material oldMaterial = mesh.material;
		// // testSound.Play();
    }

	void OnMouseDown(){
		testSound.Play();
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

}
