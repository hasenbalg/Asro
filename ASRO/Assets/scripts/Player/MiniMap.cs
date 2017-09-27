using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour {

	public Material material;
	public float scaleFactor = .007f;
	string[] mappedObjects = {"rippe"};
	public GameObject mapPlayer;
	private GameObject mapPlayer_;

	[Header("hololight")]
	public Light holoLight;
	public float holoLightIntensity;

	GameObject player;

	void BuildMap(Transform modul){
//		Debug.Log (modul.name);
		GameObject map_modul = new GameObject ();
		map_modul.name = modul.name;
		map_modul.tag = "MapModul";
		map_modul.layer = LayerMask.NameToLayer("ExplorerViewLayer"); //http://answers.unity3d.com/answers/18473/view.html
		MeshFilter mf = map_modul.AddComponent<MeshFilter> ();
		MeshRenderer mr = map_modul.AddComponent<MeshRenderer> ();
		mf.mesh = modul.GetComponent<MeshFilter> ().mesh;
		map_modul.transform.position = modul.transform.position;
		mr.material = material;
		mr.enabled = false;
		map_modul.transform.Rotate(modul.eulerAngles);
//		map_modul.transform.parent = gameObject.transform;
		map_modul.transform.SetParent (transform, false);
	}

	// Use this for initialization
	void Start () {
		GameObject map = GameObject.Find ("GameManager");
	player = GameObject.Find ("Player");
//		foreach(Transform modul in map.transform){
//			if(modul.name.Contains("group")){
//				foreach (Transform g_modul in modul.transform) {
//					BuildMap (g_modul);
//				}
//			}else{
//				BuildMap (modul);
//			}
//
//		}

		foreach(GameObject go in GameObject.FindObjectsOfType(typeof(GameObject)))
		{
			foreach (var str in mappedObjects) {
				if (go.name.Contains ("rippe")) {
					BuildMap (go.transform);
				}
			}

		}
		mapPlayer_ = Instantiate (mapPlayer);
		mapPlayer_.tag = "MapPlayer";
		mapPlayer_.GetComponent<MeshRenderer> ().enabled = false;
		mapPlayer_.transform.SetParent (transform, false);
		transform.localScale = new Vector3 (scaleFactor,scaleFactor,scaleFactor);
		holoLight.intensity = 0;

	}

	public void ToggleMap(){
		if (transform.GetChild (0).GetComponent<MeshRenderer> ().enabled) {
			foreach (Transform child in transform) {
				child.GetComponent<MeshRenderer> ().enabled = false;
			}
			mapPlayer_.GetComponent<MeshRenderer> ().enabled = false;
			holoLight.intensity = 0;
		} else {
			foreach (Transform child in transform) {
				child.GetComponent<MeshRenderer> ().enabled = true;
			}
			mapPlayer_.GetComponent<MeshRenderer> ().enabled = true;
			holoLight.intensity = holoLightIntensity;
		}

	}


	// Update is called once per frame
	void Update () {
		Vector3 position = player.transform.position;
		mapPlayer_.transform.localPosition = Vector3.Scale (position, mapPlayer_.transform.localScale *.5f);


//		transform.localRotation = Quaternion.Euler( GameObject.Find ("Player").transform.rotation.eulerAngles * -1f);
// transform.rotation = Quaternion.Lerp(player.transform.localRotation, transform.rotation, .9f);
	transform.eulerAngles = new Vector3(
		transform.rotation.x,
		player.transform.rotation.y,
			transform.rotation.z
	);
	Debug.Log(transform.rotation);
	}


}
