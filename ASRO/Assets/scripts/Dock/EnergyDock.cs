using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyDock : MonoBehaviour {

	public float timeToFillUp = 10f;
	private float intitialTime;

	public float engeryCostForPlayer = 3f;
	private GameObject indicator;
	private GameObject player;
	public bool isFilled = false;
	private float yOffset;

	public AudioClip fillUpSound;
	private AudioSource ac;

	private Renderer rd;

	// Use this for initialization
	void Start () {
		intitialTime = timeToFillUp;
		player = GameObject.Find ("Player");
		indicator = transform.Find("Indicator 1").gameObject;
		//Debug.Log ( transform.localScale);
		yOffset = indicator.transform.position.y;

		ac = GetComponent<AudioSource> ();
		ac.clip = fillUpSound;

		indicator.transform.localScale = new Vector3 (1, 0, 1);
		Vector3 level = indicator.transform.position;
		level.y = 0;
		indicator.transform.position = level;

		rd = indicator.GetComponent<Renderer> ();

	}
	
	// Update is called once per frame
	void Update () {
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

		if (Vector3.Distance (player.transform.position, transform.position) < transform.localScale.x * 1.5f) {
			timeToFillUp -= Time.deltaTime;
			indicator.transform.localScale = new Vector3 (1, (intitialTime - timeToFillUp) / intitialTime, 1);
			Vector3 level = indicator.transform.position;
			level.y = yOffset * (intitialTime - timeToFillUp) / intitialTime;
			indicator.transform.position = level;

			rd.material.SetTextureScale("_MainTex", new Vector2((intitialTime - timeToFillUp) * 10f / intitialTime, (intitialTime - timeToFillUp) * 10f/ intitialTime));

			ac.pitch = (intitialTime - timeToFillUp) / intitialTime;

			if(timeToFillUp > 0){
				// cost erngy for the player
				player.GetComponent<Energy> ().LooseEnergy(engeryCostForPlayer * Time.deltaTime);


				//attract enemies
				foreach(GameObject e in enemies){
					e.GetComponent<AI> ().makeMoreSenible (); 
				}
			}

			if (!ac.isPlaying && timeToFillUp > 0) {
				ac.Play ();
			} 
			if(ac.isPlaying && timeToFillUp <= 0){
				ac.Stop ();
			}


		} else {
			if(ac.isPlaying){
				ac.Stop ();
			}

			//attract enemies not anymore
			foreach(GameObject e in enemies){
				e.GetComponent<AI> ().makeLessSenible (); 
			}
		}
		if (timeToFillUp <= 0) {
			timeToFillUp = 0;
			isFilled = true;
		} 


	}

//	private void FlipNormals (Mesh mesh){
//		// http://wiki.unity3d.com/index.php/ReverseNormals
////		Mesh mesh = filter.mesh;
//
//		Vector3[] normals = mesh.normals;
//		for (int i=0;i<normals.Length;i++)
//			normals[i] = -normals[i];
//		mesh.normals = normals;
//
//		for (int m=0;m<mesh.subMeshCount;m++)
//		{
//			int[] triangles = mesh.GetTriangles(m);
//			for (int i=0;i<triangles.Length;i+=3)
//			{
//				int temp = triangles[i + 0];
//				triangles[i + 0] = triangles[i + 1];
//				triangles[i + 1] = temp;
//			}
//			mesh.SetTriangles(triangles, m);
//		}
//	}
//
//	public void OnTriggerEnter(Collider c){
//		if(c.gameObject.tag == "Player"){
//			Debug.Log ("HUHU");
//			if(indicator != null){
//				Mesh mesh = indicator.GetComponent<MeshFilter> ().mesh;
//				FlipNormals (mesh);
//			}
//		}
//
//
//	}
//	public void OnTriggerExit(Collider c){
//		if(c.gameObject.tag == "Player"){
//			Debug.Log ("HUHU");
//			if(indicator != null){
//				Mesh mesh = indicator.GetComponent<MeshFilter> ().mesh;
//				FlipNormals (mesh);
//			}
//		}
//	}


}
