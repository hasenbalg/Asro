using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveSound : MonoBehaviour {

	// Use this for initialization
	private AudioSource ac;
	public AudioClip drive;

	private CharacterController cc;
	private Move mv;
	void Start () {
		ac = GetComponent<AudioSource> ();
		cc = GetComponentInParent<CharacterController> ();
		mv = GetComponentInParent<Move> ();
		ac.clip = drive;
	}
	
	// Update is called once per frame
	void Update () {
		ac.pitch = mv.GetCurrentSpeed () * .2f;
		if (Mathf.Abs (cc.velocity.x) > .01f && !ac.isPlaying) {
			ac.Play ();
		}else if(Mathf.Abs (cc.velocity.x) < .01f && ac.isPlaying){
			ac.Stop ();
		}

	}
}
