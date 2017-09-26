using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DockPing : MonoBehaviour {



	public GameObject dockPrefab;
	private GameObject player, map, nextDock;
	Dock2Energy d2e;
	bool nextDockIsSet = false;
	// Use this for initialization
	void Start () {
		GameObject[] allDocks = GameObject.FindGameObjectsWithTag ("Dock2");
		for (int i = 0; i < allDocks.Length; i++) {
				if(allDocks[i].GetComponent<DockPing>() == this){
					if(i == allDocks.Length -1){
						nextDock = allDocks[0];
						continue;
					}
					nextDock = allDocks[i+1];
					continue;
				}

		}
		player = GameObject.Find ("Player");
		d2e = GetComponent<Dock2Energy> ();
		map = GameObject.Find ("Map");



	}
	
	// Update is called once per frame
	void Update () {
		if(Vector3.Distance(player.transform.position, transform.position)< d2e.loadingDistance && d2e.energyLeft == 0f && !nextDockIsSet){
			GameObject mapDock = Instantiate (dockPrefab, map.transform);
			mapDock.transform.localPosition = nextDock.transform.position;
			mapDock.GetComponent<MeshRenderer> ().enabled = false;
		}
	}
}
