using UnityEngine;
using VRStandardAssets.Utils;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.Audio;
using System.Collections.Generic;

public class Glow_Script : MonoBehaviour{
               
	[SerializeField] private Material m_OverMaterial;                                      
	[SerializeField] private VRInteractiveItem m_InteractiveItem;
	[SerializeField] private Renderer m_Renderer;
    private AudioSource Audio;
    protected string item;

    void Start()
    {
        item = gameObject.tag;
        Debug.Log("from glow "+item);
    }

	private void Awake (){
		m_Renderer.enabled = false;
		Audio = GetComponent<AudioSource> ();
	}
    /// <summary>
    /// Called when the mouse enters the GUIElement or Collider.
    /// </summary>
    void OnMouseEnter(){
        m_Renderer.enabled = true;
        m_Renderer.material = m_OverMaterial;
    }
    void OnMouseExit(){
        m_Renderer.enabled = false;
    } 

    void OnMouseDown(){
        //Audio = GetComponent<AudioSource> ();
		Audio.Play();
		VoiceManager.GetItem(gameObject.tag);
    }

	private void OnEnable(){
		m_InteractiveItem.OnOver += HandleOver;
		m_InteractiveItem.OnOut += HandleOut;
		m_InteractiveItem.OnClick += HandleClick;
	}


	private void OnDisable(){
		m_InteractiveItem.OnOver -= HandleOver;
		m_InteractiveItem.OnOut -= HandleOut;
		m_InteractiveItem.OnClick -= HandleClick;
	}


	//Handle the Over event
	private void HandleOver(){
		Debug.Log("Show over state");
        m_Renderer.enabled = true;
		m_Renderer.material = m_OverMaterial;
	}


	//Handle the Out event
	private void HandleOut(){
		Debug.Log("Show out state");
        m_Renderer.enabled = false;
	}

	//Handle the Click event
	private void HandleClick()
	{
		Debug.Log("Show click state");
		Audio.Play();
        VoiceManager.GetItem(gameObject.tag);
	}
}

