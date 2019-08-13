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

    #region bath text
    static readonly string banera_text = "la bañera";
    static readonly string toilet_text = "el inodoro";
    static readonly string sink_bath_text = "el lavamano";
    static readonly string mirror_text = "el espeho";
    #endregion

    #region bedroom text
    static readonly string Computer_chair_text = "la siya de la computadora";
    static readonly string bed_text = "la cama";
    static readonly string desk_text = "el escritorio";
    static readonly string copmuter_text = "la computadora";
    static readonly string dresser_text = "el vestidor";
    static readonly string book_text = "el libro";
    static readonly string book_shelf_text = "el estante de libros";
    #endregion

    #region Kitchen/Dinning text
    static readonly string sink_kit_text = "el fregadero";
    static readonly string table_text = "la mesa";
    static readonly string chair_text = "la siya";
    static readonly string stove_text = "la estufa";
    static readonly string pan_text = "la sarten";
    static readonly string plate_text = "el plato";
    static readonly string pot_text = "la oya";
    static readonly string teapot_text = "la tetera";
    static readonly string fridge_text = "el refrigerador";
    #endregion

    #region Livingroom text
    static readonly string tv_text = "la televisión";
    static readonly string sofa_text = "el sofa";
    static readonly string lamp_text = "la lampara";
    static readonly string accent_chair_text = "el siyon";
    static readonly string picture_frame_text = "el cuadro";
    static readonly string speaker_text = "el altavos";
    static readonly string picture_text = "la pintura";
    static readonly string trophy_text = "el trofeo";
    #endregion


    
    
    // Start is called before the first frame update
    void Start(){
        Debug.Log("from voiceMan "+ item);
        #region bathroom action
        //bathroom
        actions.Add(banera_text, overall);
        actions.Add(toilet_text, overall);
        actions.Add(sink_bath_text, overall);
        actions.Add(mirror_text, overall);
        #endregion

        #region Bedroom actions
        //bedroom
        actions.Add(Computer_chair_text, overall);
        actions.Add(bed_text, overall);
        actions.Add(desk_text, overall);
        actions.Add(copmuter_text, overall);
        actions.Add(dresser_text, overall);
        actions.Add(book_text, overall);
        actions.Add(book_shelf_text, overall);
        #endregion

        #region Kitchen/Dining actions
        //kitchen & dinning 
        actions.Add(sink_kit_text, overall);
        actions.Add(table_text, overall);
        actions.Add(chair_text, overall);
        actions.Add(stove_text, overall);
        actions.Add(pan_text, overall);
        actions.Add(plate_text, overall);
        actions.Add(pot_text, overall);
        actions.Add(teapot_text, overall);
        actions.Add(fridge_text, overall);
        #endregion

        #region Livingroom actions
        //Livingroom action 
        actions.Add(tv_text, overall);
        actions.Add(sofa_text, overall);
        actions.Add(lamp_text, overall);
        actions.Add(accent_chair_text, overall);
        actions.Add(picture_frame_text, overall);
        actions.Add(speaker_text, overall);
        actions.Add(picture_text, overall);
        actions.Add(trophy_text, overall);
        #endregion

        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());   
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech; 
        keywordRecognizer.Start();

        audio = GetComponent<AudioSource>();
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

    //function to play the correct sound
    private void overall(){
        audio.Play();
        yes = false;
    }
}
