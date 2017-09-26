using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceDocks : MonoBehaviour {


		public GameObject dock;
		public int howManyDocks;

		List<Vector3>possibleSpawnPoints;
		// Use this for initialization
		void Start () {
			possibleSpawnPoints = new List<Vector3> ();

			foreach(Transform child in transform){
				possibleSpawnPoints.Add (child.position);
			}

		for(int i = 0; i < howManyDocks; i++){
				//Instantiate (energy, possibleSpawnPoints[Random.Range (0, possibleSpawnPoints.Count)], Quaternion.identity * Quaternion.Euler(0,180,0));
				Instantiate (dock, possibleSpawnPoints[Random.Range (0, possibleSpawnPoints.Count)], Quaternion.identity );
			}
		}

}
