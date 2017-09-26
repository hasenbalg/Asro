using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkidMarks : MonoBehaviour {

	public GameObject skidMark;
	private bool halt = true;

	private CharacterController cc;
	public AudioClip rubberSqueek;

	private AudioSource ac;
	// Use this for initialization
	void Start () {
		cc = GetComponent<CharacterController> ();
		ac = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
//		Debug.Log (cc.velocity);
		if(Mathf.Abs(cc.velocity.x) < .01f && !halt){
			halt = true;
//			Debug.Log ("IIIIIIIIIIK");
			ac.clip = rubberSqueek;
			ac.Play ();
			GameObject skidm = Instantiate (skidMark, new Vector3(transform.position.x, .001f, transform.position.z), transform.rotation);
			skidm.transform.SetParent (GameObject.Find("GameManager").transform, true);
		}
		if (Mathf.Abs(cc.velocity.x) > .01f) {
			halt = false;
		}
	}
}
