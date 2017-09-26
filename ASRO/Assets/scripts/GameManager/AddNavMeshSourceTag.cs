using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddNavMeshSourceTag : MonoBehaviour {

	public string name;
	GameObject[] floorTiles;
	// Use this for initialization
	void Start () {
		GameObject[] gameObjects = (GameObject[])FindObjectsOfType(typeof(GameObject));

		for (int i=0; i < gameObjects.Length; i++){
			if(gameObjects[i].name.Contains(name)){
//				print(gameObjects[i] + "  : " + i);
				gameObjects [i].AddComponent<NavMeshSourceTag> ();
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
