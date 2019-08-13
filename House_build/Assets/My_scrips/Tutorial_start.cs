using UnityEngine;
using VRStandardAssets.Utils;
using UnityEngine.SceneManagement;
using System.Collections;
public class Tutorial_start : MonoBehaviour {

	[SerializeField] private Material m_NormalMaterial;                
	[SerializeField] private Material m_OverMaterial;                  
	[SerializeField] private Material m_ClickedMaterial;                     
	[SerializeField] private VRInteractiveItem m_InteractiveItem;
	[SerializeField] private Renderer m_Renderer;

	private void Awake ()
	{
		m_Renderer.material = m_NormalMaterial;
	}


	private void OnEnable()
	{
		m_InteractiveItem.OnOver += HandleOver;
		m_InteractiveItem.OnOut += HandleOut;
		m_InteractiveItem.OnClick += HandleClick;
	}


	private void OnDisable()
	{
		m_InteractiveItem.OnOver -= HandleOver;
		m_InteractiveItem.OnOut -= HandleOut;
		m_InteractiveItem.OnClick -= HandleClick;
	}


	//Handle the Over event
	private void HandleOver()
	{
		Debug.Log("Show over state");
		m_Renderer.material = m_OverMaterial;
	}

	//Handle the Out event
	private void HandleOut()
	{
		m_Renderer.material = m_NormalMaterial;
	}

	//Handle the Click event
	private void HandleClick()
	{
		SceneManager.LoadScene("Tutorial");
	}
}
