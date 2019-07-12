using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UnityEngine.Windows.Speech;

public class Tset : MonoBehaviour
{
    public static Tset tset = null;
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();
    public AudioSource testSound;
    private bool yes;
    // actions.Add("la mesa", mesa);
    // actions.Add("okay", okay);
    void Awake(){
        if (tset == null){
            tset = this;
        }
        else{
            Destroy(gameObject);
        }
    }
    void Start(){
			testSound = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void OnMouseDown()
    {
        actions.Add("la silla", mesa);
        actions.Add("okay", okay);
        yes = true;

        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());   
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech; 
        keywordRecognizer.Start();
    }

    private void RecognizedSpeech(PhraseRecognizedEventArgs speech){
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }

    private void mesa(){
        Debug.Log("you said la silla");
        if (yes == true){
            testSound.Play();
        }
        yes = false;
    }

    private void okay(){
        Debug.Log("you said okay");
    }

    private void OnDisable(){
        keywordRecognizer.OnPhraseRecognized -= RecognizedSpeech;
    }
}
