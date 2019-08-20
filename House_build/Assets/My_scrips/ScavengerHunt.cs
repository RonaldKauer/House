using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScavengerHunt : MonoBehaviour
{
	public static ScavengerHunt sca = null;
	protected static int tracker = 0;

	public AudioClip[] HuntItemsAudioClips; //the audio fro the hunt items
	public AudioClip[] HuntQuestionsAudioClips; // the auido for hunt "donde esta.."
	public GameObject[] HuntItems; // the items for the hunt
	public string[] HuntPrompts; // theh string that display "donde esta" for the hunt
	public List<int> checking = new List<int>();

	public AudioClip[] itemsAudioClips; //the audio fro the items
	public AudioClip[] questionsAudioClips; // the auido "donde esta.."
	public GameObject[] Items; // the items
	public string[] Prompts; // theh string that display "donde esta"

    public int min = 0;
    public int max = 28;
	public System.Random _rnd = new System.Random();

	public Text  _thetraker;
	public Text _thePromts;
	public AudioSource A;
	public List<AudioSource> aud;
    public Text endText;

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

        HuntItemsAudioClips = new AudioClip[10];
        HuntQuestionsAudioClips = new AudioClip[10];
        HuntItems = new GameObject[10];
        HuntPrompts = new string[10];
        RandTheHunt();

		A.clip = HuntQuestionsAudioClips[tracker];
		A.Play ();

		updateText();

	}

    public void RandTheHunt(){
        //i have 28 items to choose from (need to be 30)
        for(int j = 0; j < 10; ++j){
            int num = _rnd.Next(min, max);
			Debug.Log(num);
			if(!checking.Contains(num)){
				checking.Add(num);
				// gwtting from the overall array into the hunt items array fro the actual hunt
				HuntItems[j] = Items[num];
				HuntItemsAudioClips[j] = itemsAudioClips[num];
				HuntQuestionsAudioClips[j] = questionsAudioClips[num];
				HuntPrompts[j] = Prompts[num];
			}
			else{
				Debug.Log("num was already in");
				--j;
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
		return HuntItems [tracker];
	}

	public void callRoutineAndIncrementTracker(){
		Debug.Log (tracker);
		if (tracker < HuntItemsAudioClips.Length) {
			StartCoroutine(PlayAudio ());
		}
	}

	IEnumerator PlayAudio(){
		Debug.Log ("PlayClip");
		A.clip = HuntItemsAudioClips [tracker];
		A.Play ();
		tracker++;
		yield return new WaitForSeconds (A.clip.length + 1);
		A.clip = HuntQuestionsAudioClips [tracker];
		A.Play ();
	}

}
