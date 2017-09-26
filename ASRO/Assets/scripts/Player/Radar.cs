using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour {


	public GameObject enemy, battery; 
	public float monitoringDistance;
	// Use this for initialization

	Dictionary<int, GameObject> monitoredEnemies = new Dictionary<int, GameObject>();
	Queue<int> markers2Remove = new Queue<int>();

	GameObject player;
	void Start () {
		player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		foreach(GameObject e in GameObject.FindGameObjectsWithTag("Enemy")){
			
			if(Vector3.Distance(e.transform.position, player.transform.position) <= monitoringDistance && !monitoredEnemies.ContainsKey(e.GetInstanceID())){
				Debug.Log (monitoredEnemies.Count);
				GameObject enemyMarker = Instantiate (enemy, enemy.transform.position, Quaternion.identity);
				enemyMarker.GetComponent<EnemyRadar> ().referenceId = e.GetInstanceID ();
				enemyMarker.transform.SetParent(transform, false);
				monitoredEnemies.Add (e.GetInstanceID(), enemyMarker);
			}
		}

		foreach(GameObject enemy in GameObject.FindGameObjectsWithTag("EnemyRadar")){
			bool enemyFound = false;
			foreach (GameObject e  in GameObject.FindGameObjectsWithTag("Enemy")) {
				if(e.GetInstanceID() == enemy.GetComponent<EnemyRadar>().referenceId){
					enemyFound = true;
				}
			}
			if(!enemyFound){
				Destroy (enemy);
			}
		}




		foreach (GameObject e in GameObject.FindGameObjectsWithTag("Enemy")) {
			if(monitoredEnemies.ContainsKey(e.GetInstanceID())){
				Vector3 markerPos = Vector3.Scale(
					e.transform.position.normalized,
					GameObject.Find("Monitor").transform.localScale
				);
					
				monitoredEnemies [e.GetInstanceID()].transform.localPosition = markerPos / monitoringDistance;

				transform.localRotation = player.transform.rotation * Quaternion.Euler(-90f,0f,0f);


			}
		}
	}
}
