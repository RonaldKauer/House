using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UnityEngine.Windows.Speech;
using UnityEngine.SceneManagement;

public class Tset : MonoBehaviour
{
    public static Tset tset = null;
    // private KeywordRecognizer keywordRecognizer;
    // private Dictionary<string, Action> actions = new Dictionary<string, Action>();
    // public AudioSource testSound;
    // private bool yes;
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
		// testSound = GetComponent<AudioSource>();
        // actions.Add("la siya", mesa);
        // actions.Add("okay", okay);
        // yes = true;

        // keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());   
        // keywordRecognizer.OnPhraseRecognized += RecognizedSpeech; 
        // keywordRecognizer.Start();
    }

    /// <summary>
    /// OnMouseDown is called when the user has pressed the mouse button while
    /// over the GUIElement or Collider.
    /// </summary>
    void OnMouseDown()
    {
        SceneManager.LoadScene("Bathroom");
    }
    // Start is called before the first frame update

    // private void RecognizedSpeech(PhraseRecognizedEventArgs speech){
    //     Debug.Log(speech.text);
    //     actions[speech.text].Invoke();
    // }

    // private void mesa(){
    //     Debug.Log("you said la silla");
    //     if (yes == true){
    //         testSound.Play();
    //     }
    //     yes = false;
    // }

    // private void okay(){
    //     Debug.Log("you said okay");
    // }

    // private void OnDisable(){
    //     keywordRecognizer.OnPhraseRecognized -= RecognizedSpeech;
    // }
}
