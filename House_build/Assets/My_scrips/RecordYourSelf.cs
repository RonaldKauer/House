using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class RecordYourSelf : MonoBehaviour
{
   public GameObject canvasObj;
//    public GameObject canvasObj2;
    // Start is called before the first frame update
     // Get list of Microphone devices and print the names to the log
    public AudioSource testSound;
		// Material mat;
		

    void Start(){
			testSound = GetComponent<AudioSource>();
			//canvasObj = transform.Find("Chair_Menu").gameObject as GameObject;
			// canvasObj.SetActive(false);
		// 	MeshRenderer mesh = GetComponent<MeshRenderer>();
		//  	Material oldMaterial = mesh.material;
		// // testSound.Play();
    }


	// void OnMouseDown(){
	// 	testSound.Play();
	// 	canvasObj.SetActive(true);
	// }

	// void Update(){
	// 	if((OVRInput.Get (OVRInput.Button.Two))){
	// 		canvasObj.SetActive(true);
	// 		testSound.Play();
	// 	}
	// }
	

	void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hand" )
        {
            // testSound.Play();
			canvasObj.SetActive(true);
			// canvasObj2.SetActive(true);
        }
    }


}
