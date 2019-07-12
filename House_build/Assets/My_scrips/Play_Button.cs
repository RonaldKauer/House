using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play_Button : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource testSound;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PLay_Button")
        {
            testSound.Play();
        }
    }

}
