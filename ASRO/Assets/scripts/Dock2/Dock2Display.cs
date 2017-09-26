using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dock2Display : MonoBehaviour {


	private TextMesh tm;
	private Dock2Manager d2m;
	// Use this for initialization
	void Start () {
		tm = GetComponent<TextMesh> ();
		d2m = (Dock2Manager)GameObject.Find ("GameManager").GetComponent<Dock2Manager> ();
	}
	
	// Update is called once per frame
	void Update () {
		tm.text = Mathf.Round(d2m.GetCommonAverage() * 100f).ToString() + " %";
	}
}
