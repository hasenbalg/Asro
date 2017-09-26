using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryVanish : MonoBehaviour {

	public AudioClip vanishSound;
	private AudioSource ac;

	private bool collected = false;
	private bool readyToDie = false;
	// Use this for initialization
	void Start () {
		ac = GetComponent<AudioSource> ();
		ac.clip = vanishSound;
	}
	
	public void Vanish(){
		collected = true;
	}

	public void Update(){
		if(collected && !ac.isPlaying && !readyToDie){
			ac.Play ();
			transform.GetChild(0).GetComponent<MeshRenderer> ().enabled = false;
			readyToDie = true;

		}
		if (collected && !ac.isPlaying && readyToDie) {
			Destroy (gameObject);
		}
	}
}
