using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menuScript : MonoBehaviour {

	public Button startText;
	public Button settingsText;
	public Button quitText;
	public AudioClip impact;
	public bool jumptostart;
	public double timetoswitch; 
	AudioSource audio;

	//public MovieTexture movTexture;

	// Use this for initialization
	void Start () {
		if (quitText) {
			startText = startText.GetComponent<Button>();
			quitText = quitText.GetComponent<Button>();
		}
		audio = GetComponent<AudioSource>();

	}

	public void StartLevel(){
		SceneManager.LoadScene ("level1");
//		print ("Start gedrückt");
	}
	public void QuitGame(){
		Application.Quit ();
//		print ("Game beendet");
	}

	public void playHover(){
		//hover.Play();

		audio.PlayOneShot(impact, 0.7F);
//		print ("hoverd");
		//hover.Play(44100);
	}

	// Update is called once per frame
	void Update () {
		if (jumptostart == true && Time.timeSinceLevelLoad >= timetoswitch) {
			SceneManager.LoadScene ("start");
		}
		
	}
}
