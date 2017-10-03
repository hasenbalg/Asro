using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyEnergy : MonoBehaviour {

	public float energy = 1000;
//	private TextMesh text;

	public AudioClip deathSound;
	private AudioSource ac;

	private bool readyToDie = false;
    Animator animator;
    float fullEnergy;


	void Start(){
//		text = gameObject.AddComponent<TextMesh> ();
		ac = GetComponent<AudioSource> ();
        animator = GetComponent<Animator>();
        fullEnergy = energy;
	}

	void Update(){
//		text.text = energy.ToString ();

		if (energy <= 0) {
			if(!readyToDie){
				Die ();
				readyToDie = true;
			}
		}
        animator.SetFloat("life", energy/fullEnergy);
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
