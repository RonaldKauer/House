using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager LM = null;
    private static bool been_here = false;
    private AudioSource introAudio;

    void Awake()
    {
        if(LM == null){
            LM = this;
        }
        else{
            Destroy(gameObject);
        }
        //when i go to a new scean this wont get destroy
        DontDestroyOnLoad(this);
        
        introAudio = GetComponent<AudioSource>();

        if(!been_here){
            introAudio.Play();
            been_here = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
