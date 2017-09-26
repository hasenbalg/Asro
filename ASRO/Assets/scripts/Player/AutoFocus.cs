using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoFocus : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 fwd = transform.TransformDirection(Vector3.forward);
		RaycastHit hit;
		if (Physics.Raycast (transform.position, fwd, out hit, Mathf.Infinity,(1 << LayerMask.NameToLayer("ExplorerViewLayer")))) {
			// Debug.Log(hit.transform.position);
			Vector3 afp = transform.GetChild (3).transform.position;
			afp = Vector3.Lerp (afp, hit.transform.position, .1f);
			transform.GetChild (3).transform.position = afp;
		}
	}
}
