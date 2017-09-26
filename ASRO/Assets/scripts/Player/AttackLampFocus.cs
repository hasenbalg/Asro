using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackLampFocus : MonoBehaviour {


	Light laser;

	float oldAngle;
	ViewSwitch vs;
	// Use this for initialization
	void Start () {
		laser = GetComponent<Light> ();
		vs = GameObject.FindGameObjectWithTag ("Player").GetComponent<ViewSwitch> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (vs.GetStatus() == Views.FRAG) {
			laser.enabled = true;
		} else {
			laser.enabled = false;
		}
	}
}
