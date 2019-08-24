using UnityEngine;
using VRStandardAssets.Utils;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.Audio;
using System.Collections.Generic;

public class Scavengerhunt_glow : MonoBehaviour
{
	[SerializeField] private Material m_OverMaterial;                                      
	[SerializeField] private VRInteractiveItem m_InteractiveItem;
	[SerializeField] private Renderer m_Renderer;
	[SerializeField] private Material m_ClickedMaterialCorrect; 
	[SerializeField] private Material m_ClickedMaterialIncorrect; 
    private AudioSource Audio;
    protected string item;

    void Start()
    {
		ScavengerHunt.sca._wrongNum = 0;
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
	    Debug.Log (ScavengerHunt.sca.getObject());
		// if level is 1 and item is clicked on, update score and level
		if (this.gameObject == ScavengerHunt.sca.getObject()) {
			ScavengerHunt.sca._numWrong.Add(ScavengerHunt.sca._wrongNum);
			Debug.Log(ScavengerHunt.sca._wrongNum);
			ScavengerHunt.sca._wrongNum = 0;
			ScavengerHunt.sca.callRoutineAndIncrementTracker ();
			m_Renderer.material = m_ClickedMaterialCorrect;
            ScavengerHunt.sca.updateText();
		}
		else{
			ScavengerHunt.sca._wrongNum++;
			Debug.Log(ScavengerHunt.sca._wrongNum);
			m_Renderer.material = m_ClickedMaterialIncorrect;
			if(ScavengerHunt.sca._wrongNum == 3){
				ScavengerHunt.sca.callRoutineAndIncrementTracker ();
            	ScavengerHunt.sca.updateText();
			}
		}
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
	    Debug.Log (ScavengerHunt.sca.getObject());
		// if level is 1 and item is clicked on, update score and level
		if (this.gameObject == ScavengerHunt.sca.getObject()) {
			ScavengerHunt.sca._numWrong.Add(ScavengerHunt.sca._wrongNum);
			Debug.Log(ScavengerHunt.sca._wrongNum);
			ScavengerHunt.sca._wrongNum = 0;
			ScavengerHunt.sca.callRoutineAndIncrementTracker ();
			m_Renderer.material = m_ClickedMaterialCorrect;
            ScavengerHunt.sca.updateText();
		}
		else{
			ScavengerHunt.sca._wrongNum++;
			Debug.Log(ScavengerHunt.sca._wrongNum);
			m_Renderer.material = m_ClickedMaterialIncorrect;
			if(ScavengerHunt.sca._wrongNum == 3){
				ScavengerHunt.sca.callRoutineAndIncrementTracker ();
            	ScavengerHunt.sca.updateText();
			}
		}
}
