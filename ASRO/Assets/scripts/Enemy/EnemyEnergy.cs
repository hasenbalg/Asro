using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyEnergy : MonoBehaviour {

	public float energy = 1000;
//	private TextMesh text;

	public AudioClip deathSound;
	private AudioSource ac;

	private bool readyToDie = false;



	void Start(){
//		text = gameObject.AddComponent<TextMesh> ();
		ac = GetComponent<AudioSource> ();
	}

	void Update(){
//		text.text = energy.ToString ();

		if (energy <= 0) {
			if(!readyToDie){
				Die ();
				readyToDie = true;
			}
		}
	}


	public void LooseEnergy (float damage) {
		energy -= damage;


		//		Debug.Log (c.ToString());

	}

	private void Die(){
		Destroy (GetComponent<AI> ());
		Destroy (GetComponent<EnemyFight> ());
		Destroy (GetComponent<Renderer> ());
		ac.clip = deathSound;
		ac.Play ();
		GameObject.Find ("HUD").GetComponent<HUDManager> ().AddSkillPoint();
		Destroy (gameObject, deathSound.length);

	}

}
