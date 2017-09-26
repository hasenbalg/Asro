using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerManager : MonoBehaviour {

	public GameObject level;
	public GameObject enemie;
	public GameObject player;
	public GameObject gloom;

	// Use this for initialization
	void Start () {
		level.layer = LayerMask.NameToLayer("ExplorerViewLayer");
		enemie.layer = LayerMask.NameToLayer("EnemiesViewLayer");
		gloom.layer = LayerMask.NameToLayer("EnemiesViewLayer");

		player.layer = LayerMask.NameToLayer("ExplorerViewLayer");
//		player.layer = LayerMask.NameToLayer("EnemiesViewLayer");
//		player.layer = LayerMask.NameToLayer("Fraglayer");

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
