using UnityEngine;
using VRStandardAssets.Utils;
using UnityEngine.SceneManagement;
using System.Collections;

public class Tutorial_button : MonoBehaviour
{
	[SerializeField] private Material m_NormalMaterial;                
	[SerializeField] private Material m_OverMaterial;                  
	[SerializeField] private Material m_ClickedMaterial;               
	// [SerializeField] private Material m_DoubleClickedMaterial;         
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
		// m_InteractiveItem.OnDoubleClick += HandleDoubleClick;
	}


	private void OnDisable()
	{
		m_InteractiveItem.OnOver -= HandleOver;
		m_InteractiveItem.OnOut -= HandleOut;
		m_InteractiveItem.OnClick -= HandleClick;
		// m_InteractiveItem.OnDoubleClick -= HandleDoubleClick;
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
		Debug.Log("Show out state");
		m_Renderer.material = m_NormalMaterial;


	}


	//Handle the Click event
	private void HandleClick()
	{
		Debug.Log("IM CLICKING PLS");
		SceneManager.LoadScene(1);
	}
		
	// //Handle the DoubleClick event
	// private void HandleDoubleClick()
	// {

	// 	// Create a temporary reference to the current scene.
	// 	Scene currentScene = SceneManager.GetActiveScene ();

	// 	// Retrieve the name of this scene.
	// 	string sceneName = currentScene.name;

	// 	Debug.Log("Show double click");
	// 	m_Renderer.material = m_NormalMaterial;
	// 	// m_Renderer.material = m_DoubleClickedMaterial;

	// 	if (sceneName == "World") {
	// 		itemText.SetActive (false);
	// 	}
	// }
}
