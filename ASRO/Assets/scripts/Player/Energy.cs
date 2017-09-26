using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Energy : MonoBehaviour {

	public float energy = 1000f;
	public float looseEnergyOverFactor = .05f;

	[Header("Light")]
	public Light playerLight;
	public float lowEnergyWarnigPercent = .3f;
	[Header("Sound")]
	public AudioClip collectBattery;
	public AudioClip lowEnergy;
	public Texture flickerTexture;

	private float looseEnergyOverTime = .5f;
	private float fullEnergy;
	private float fullIntensity;
	private AudioSource ac;


	private double nextFlicker;
	private bool isFlickering = false;

    void Start(){
		ac = GetComponent<AudioSource> ();

		fullEnergy = energy;
		fullIntensity = playerLight.intensity;


		// add flicker on low energy

	}


	public void LooseEnergy (float damage) {
		energy -= damage;
		playerLight.intensity = fullIntensity * (energy / fullEnergy);
		if (energy <= 0) {
//			Destroy (gameObject);
			GameEnd.GameOver ();
		}
	}

	public void GainEnergy(float percent){
		float gain = fullEnergy * percent / 100f;
		energy += gain;
		energy = Mathf.Clamp (energy, -Mathf.Infinity, fullEnergy);
	}


	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Energy")
		{
			GainEnergy (other.GetComponent<EnergyDispense>().fillUpPercent);
			other.GetComponent<BatteryVanish> ().Vanish ();
		}
	}

	void Update(){
		if(energy / fullEnergy < lowEnergyWarnigPercent){
			LowEnergyWarning ();
		}

		//loose energy over time
		energy -= (looseEnergyOverTime * Time.deltaTime);
	}

	public void LowEnergyWarning(){
		// flicker
		double currentTime = Time.realtimeSinceStartup;
		if (currentTime > nextFlicker) {
			nextFlicker = Random.Range(1, 5) + currentTime;
			isFlickering = true;

			ac.clip = lowEnergy;
			ac.Play ();
		} else {
			isFlickering = false;
		}


	}

	public void LooseEnergyOverTime(float angle){
		looseEnergyOverTime = angle * looseEnergyOverFactor;
	}

	void OnGUI() {
		if(isFlickering){
			GUI.DrawTexture(new Rect(0,0,Screen.width, Screen.height), flickerTexture);
		}
	}
}
