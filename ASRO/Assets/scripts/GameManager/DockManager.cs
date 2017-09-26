using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DockManager : MonoBehaviour {


	private GameObject[] docks;
	private float totalTimeLeft = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		docks = GameObject.FindGameObjectsWithTag("Dock");
//		Debug.Log (docks.Length + "Docks length");

		int sum = 0;
		foreach(GameObject go in docks){
			if (go.GetComponent<EnergyDock> ().isFilled) {
				sum++;
			}

		}
		if (sum == docks.Length) {
			Debug.Log ("Game OVER man");
			foreach(GameObject go in docks){
				Destroy (go);

			}
//			SceneManager.LoadScene ("start");
			GameEnd.GameWin ();
		}
	}
}
