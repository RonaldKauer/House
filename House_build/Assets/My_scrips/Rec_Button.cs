using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rec_Button : MonoBehaviour
{
    // Start is called before the first frame update

    private bool compared_done = false;
    private AudioSource yourVoice;

    private List<string> MicNames;

    private string M;

    void Start()
    {
        yourVoice = GetComponent<AudioSource>();
        foreach (string device in Microphone.devices) {
			//MicNames.Add(device);
            
            M = device;
            Debug.Log("Name: " + M + "From Device");
            break;
            //Debug.Log("Name: " + MicNames[0] + "----------");
        }
    }

    // Update is called once per frame
    void Update()
    {
           
    }

       void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Rec_Button")
        {
            if(compared_done == false){
                yourVoice.clip = (Microphone.Start (M, true, 5, 44100));

            }
            Debug.Log("This must print");
            yourVoice.Play();
        }
    }

}
