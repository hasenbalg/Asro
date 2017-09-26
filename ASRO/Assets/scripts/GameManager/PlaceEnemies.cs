using System.Collections.Generic;
using UnityEngine;

public class PlaceEnemies : MonoBehaviour {
	public GameObject[] enemies;
	public int howManyEnemies;

	List<Vector3>possibleSpawnPoints;
	// Use this for initialization
	void Start () {
		possibleSpawnPoints = new List<Vector3> ();

		foreach(Transform child in transform){
			//Debug.Log (child.position);
			possibleSpawnPoints.Add (child.position);
		}

		for(int i = 0; i < howManyEnemies; i++){
			Instantiate (enemies[Random.Range(0, enemies.Length)], possibleSpawnPoints[Random.Range (0, possibleSpawnPoints.Count)], Quaternion.identity * Quaternion.Euler(0,180,0));
		}
	}
	

}
