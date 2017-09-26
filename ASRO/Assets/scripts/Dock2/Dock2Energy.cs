using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dock2Energy : MonoBehaviour {

	public Material light, dark;

	private float fullEnergy = 1000;
	public float energyLoadingSpeed= 20f;
	public float energyLeft;
	public float loadingDistance = 1f;
	public AudioClip loadingSound;
	private AudioSource ac;
	GameObject[] bulbs;

	public bool isFilled = false;

	private GameObject player;
	public float engeryCostForPlayer;
	// Use this for initialization
	void Start () {
		List<GameObject> bulbsList = new List<GameObject>();
		foreach (Transform bulb in transform) {
			if(bulb.name.Contains("Bulb")){
				bulbsList.Add (bulb.gameObject);
			}
		}
		bulbs = (GameObject[])bulbsList.ToArray ();


		player = GameObject.FindGameObjectWithTag ("Player");
//		Debug.Log (player.name);
		energyLeft = 0;
		ac = GetComponent<AudioSource> ();

		ac.clip = loadingSound;
//
//		foreach(GameObject bulb in bulbs){
//			Debug.Log ("HUHU");
//			bulb.GetComponent<Renderer> ().material = dark;
//		}
		energyLeft = fullEnergy;
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (transform.position, player.transform.position) <= loadingDistance) {
			energyLeft -= energyLoadingSpeed * Time.deltaTime;
			ac.pitch = (fullEnergy - energyLeft) / fullEnergy;

			if (energyLeft > 0 && !ac.isPlaying) {
				ac.Play ();

			}

			// sound off when fully loaded
			if (energyLeft < 0 && ac.isPlaying) {
				ac.Stop ();
			}



			for (int i = 0; i < bulbs.Length; i++) {
				// Debug.Log ((fullEnergy - energyLeft) / fullEnergy);
				if ((fullEnergy - energyLeft) / fullEnergy > (float)i / bulbs.Length) {
					bulbs [i].GetComponent<Renderer> ().material = light;
				}
			}

			//cost player energy
			if (energyLeft > 0) {
				// cost erngy for the player
				player.GetComponent<Energy> ().LooseEnergy (engeryCostForPlayer * Time.deltaTime);


				//attract enemies
				foreach (GameObject e in GameObject.FindGameObjectsWithTag("Enemy")) {
					e.GetComponent<AI> ().makeMoreSenible (); 
				}

			}
			if (energyLeft < 0) {
				isFilled = true;
				energyLeft = 0;
			}
		} else {
			ac.Stop ();
		}

	}

	public float GetPercent(){
		return (fullEnergy - energyLeft) / fullEnergy;
	}
}
