using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScavengerHunt : MonoBehaviour
{
	public static ScavengerHunt sca = null;
	protected static int tracker = 0;
	public AudioClip[] itemsAudioClips; //the audio fro the items
	public AudioClip[] questionsAudioClips; // the auido "donde esta.."
	public GameObject[] Items; // the items
	public string[] Prompts; // theh string that display "donde esta"

	public AudioClip[] HuntitemsAudioClips; //the audio fro the hunt items
	public AudioClip[] HuntquestionsAudioClips; // the auido for hunt "donde esta.."
	public GameObject[] HuntItems; // the items for the hunt
	public string[] HuntPrompts; // theh string that display "donde esta" for the hunt
	public List<int> checking = new List<int>();

    public int min = 0;
    public int max = 1;
	public System.Random _rnd = new System.Random();

	public Text  _thetraker;
	public Text _thePromts;
	// public Text touchScoreText;
	// public Text touchPromptText;
	// public Text ScoreText;
	// public Text PromptText;
	public AudioSource A;
	public List<AudioSource> aud;
    public Text endText;
    int EndOfTextCount = 0;
    private int i = 0;

	void Awake()
	{
		if(sca == null){
			sca = this;
		}
		else{
			Destroy(gameObject);
		}
	}

    void Start(){
		A = GetComponent<AudioSource> ();

        HuntitemsAudioClips = new AudioClip[10];
        HuntquestionsAudioClips = new AudioClip[10];
        HuntItems = new GameObject[10];
        HuntPrompts = new string[10];
        RandTheHunt();

		A.clip = HuntquestionsAudioClips [tracker];
		A.Play ();

		updateText();

	}

    public void RandTheHunt(){
        //i have 28 items to choose from (need to be 30)
        for(int i = 0; i < 2; ++i){
            int num = _rnd.Next(min, max+1);
			if(!checking.Contains(num)){
				checking.Add(num);
				// gwtting from the overall array into the hunt items array fro the actual hunt
				HuntItems[i] = Items[num];
				HuntitemsAudioClips[i] = itemsAudioClips[num];
				HuntquestionsAudioClips[i] = questionsAudioClips[num];
				HuntPrompts[i] = Prompts[num];
			}
			else{
				--i;
			}
        }
    }

	void Update(){
		if(Input.GetKey("escape")){
			Debug.Log ("Quit");
			Application.Quit();
			}

		 if ((OVRInput.GetDown(OVRInput.Button.One)) || Input.GetMouseButtonDown(0)) {
			if (i < aud.Count) {
				aud [i].Play ();
				i++;
			}
		}
		
	}

	public void updateText(){
        Debug.Log("End ");
		_thetraker.text = tracker.ToString() + "/10 itesm found";
		_thePromts.text = HuntPrompts[tracker].ToString();
        // touchScoreText.text = tracker.ToString() + "/15 items found";
		// touchPromptText.text = Prompts [tracker].ToString ();
		// ScoreText.text = tracker.ToString()+ "/15 items found";
		// PromptText.text = Prompts[tracker].ToString();
        //endText.text = "Thank you for playing";
        
        if (tracker == (aud.Count - 1))
        {
            Debug.Log("ended");
            endText.text = "Thank you for playing";
        }
    }

	public int getTracker(){
		return tracker;
	}

	public GameObject getObject(){
		return Items [tracker];
	}

	public void callRoutineAndIncrementTracker(){
		Debug.Log (tracker);
		if (tracker < HuntitemsAudioClips.Length) {
			StartCoroutine(PlayAudio ());
		}
	}

	IEnumerator PlayAudio(){
		Debug.Log ("PlayClip");
		A.clip = HuntitemsAudioClips [tracker];
		A.Play ();
		tracker++;
		yield return new WaitForSeconds (A.clip.length + 1);
		A.clip = HuntquestionsAudioClips [tracker];
		A.Play ();
	}

}
