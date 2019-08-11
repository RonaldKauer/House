using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;
using System;

public class VoiceManager : MonoBehaviour
{
    private static KeywordRecognizer keywordRecognizer;
    private static Dictionary<string, Action> actions = new Dictionary<string, Action>();
    public AudioClip testSound;
    static AudioSource audio;

    static string item;
    static bool yes = false;

    static readonly string banera_text = "la bañera";
    static readonly string toilet_text = "el inodoro";
    static readonly string sink_text = "el fregadero";
    static readonly string mirror_text = "el espejo";
    

    // Start is called before the first frame update
    void Start(){
        Debug.Log("from voiceMan "+ item);
        actions.Add(banera_text, banera);
        actions.Add(toilet_text, inodoro);
        actions.Add(sink_text, sink);
        actions.Add(mirror_text, mirror);

        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());   
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech; 
        keywordRecognizer.Start();

        audio = GetComponent<AudioSource>();
    }
    private void banera(){
        Debug.Log("you said la bañera");
        audio.Play();
        yes = false;
    }

    private void inodoro(){
        Debug.Log("you said toilet");
        audio.Play();
        yes = false;
    }

    private void sink(){
        Debug.Log("you said sink");
        audio.Play();
        yes = false;
    }

    private void mirror(){
        Debug.Log("you said sink");
        audio.Play();
        yes = false;
    }

    private void RecognizedSpeech(PhraseRecognizedEventArgs speech){
        Debug.Log(speech.text);
        if(yes && speech.text == item){
            audio.clip = testSound;
            actions[speech.text].Invoke();
        }
    }

    public static void GetItem (string item_tag){
        item = item_tag;
        Debug.Log("item = " + item);
        yes = true;
    }

}
