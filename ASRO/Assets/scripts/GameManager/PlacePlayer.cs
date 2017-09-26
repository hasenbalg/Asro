using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacePlayer : MonoBehaviour {

	GameObject player;
	// Use this for initialization
	void Start () {
		player =  GameObject.FindGameObjectsWithTag("Player")[0]; 
		//player.transform.position = transform.GetChild (0).transform.position;
		//Instantiate (player, , Quaternion.identity);
		player.transform.position = transform.GetChild (0).transform.position;
		//player.transform.rotation = transform.GetChild (0).transform.rotation * Quaternion.Euler (0, 0, 0);
	}

}
