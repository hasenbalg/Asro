using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapVisibity : MonoBehaviour {
	private float howLongIsTheModulVisible = 1f;
	public Material invisibleMat;


	private Material visibleMat;
	private double[] timeLastVisit;
	private GameObject player;
	private GameObject[] modules;

	// Update is called once per frame
	void Update () {
		double currentTime = Time.realtimeSinceStartup;
		player = GameObject.FindGameObjectWithTag ("MapPlayer");
		modules = GameObject.FindGameObjectsWithTag ("MapModul");


		if(timeLastVisit == null){ // modules dont exist in start yet
			timeLastVisit = new double [modules.Length];
			for(int i = 0; i < timeLastVisit.Length; i++){
				timeLastVisit[i] = currentTime - float.MaxValue;
			}
			visibleMat = modules [0].GetComponent<Renderer> ().material;
		}


		for(int i = 0; i < modules.Length; i++){
			if(Vector3.Distance(modules[i].transform.position, player.transform.position) <= .03f){
				timeLastVisit[i] = currentTime;
			}

			if (currentTime - timeLastVisit [i] >= howLongIsTheModulVisible) {
				modules [i].GetComponent<Renderer> ().material = invisibleMat;
//				modules [i].GetComponent<Renderer> ().material = visibleMat;
			} else {
				modules [i].GetComponent<Renderer> ().material = visibleMat;
			}
		}
//		Debug.Log (howLongIsTheModulVisible);
	}

	public void SetHowLongTheMapIsVisible(float seconds){
		howLongIsTheModulVisible = seconds;
//		Debug.Log (howLongIsTheModulVisible);
	}
}
