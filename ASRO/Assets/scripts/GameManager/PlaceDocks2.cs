using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceDocks2 : MonoBehaviour {

	public GameObject dock2;
	private GameObject[] docks2Placehoders;

	[Range(1, 10)]
	public int maxNumDocks = 5;

	private bool placeHolderNumReached = false;


	void Start(){
		string output = "";
		foreach(GameObject g in GameObject.FindGameObjectsWithTag("Dock2Placeholder")){
			output += g.GetInstanceID().ToString();
		}
		Debug.Log (output);

		GameObject[] docks2Placehoders = reshuffle (GameObject.FindGameObjectsWithTag("Dock2Placeholder"));

		 output = "";
		foreach(GameObject g in docks2Placehoders){
			output += g.GetInstanceID().ToString();
		}
		Debug.Log (output);

		
		for(int i = 0; i < maxNumDocks; i++){
			Instantiate (dock2, docks2Placehoders[i].transform.position, docks2Placehoders[i].transform.rotation);
		}

		foreach (GameObject d2ph in GameObject.FindGameObjectsWithTag("Dock2Placeholder")) {
			Destroy(d2ph);
		}

	}

	GameObject[] reshuffle(GameObject[] gos)	{
//		https://forum.unity3d.com/threads/randomize-array-in-c.86871/
		// Knuth shuffle algorithm :: courtesy of Wikipedia :)
		GameObject[] gosCopy = gos;

		for (int t = 0; t < gosCopy.Length; t++ )
		{
			GameObject tmp = gosCopy[t];
			int r = Random.Range(t, gosCopy.Length);
			gosCopy[t] = gosCopy[r];
			gosCopy[r] = tmp;
		}

		return gosCopy;
	}



	
}
