using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillLevels : MonoBehaviour {


	Transform[] points;

	public Material dark, bright, highlight;

	[Range(0,3)]
	public int level;

	void Start () {


		List<Transform> pointList = new List<Transform>();
		foreach(Transform t in transform){
			pointList.Add(t);
		}
		pointList.RemoveAt (0);
		points = pointList.ToArray ();

		DisableAll ();
		Enable ();

		transform.GetChild (0).GetComponent<Renderer> ().material = bright;
	}


	private void DisableAll(){
		foreach(Transform p in points){
			p.GetComponent<Renderer> ().material = dark;
		}
	}

	private void Enable(){
		for(int i = 0; i < points.Length; i++){
			if(i < level){
				points[i].GetComponent<Renderer> ().material = highlight;
			}
		}

	}

	public void Select(){
		transform.GetChild (0).GetComponent<Renderer> ().material = highlight;
	}

	public void Deselect(){
		transform.GetChild (0).GetComponent<Renderer> ().material = bright;
	}

	public bool LevelUp(){
		if (level < 3) {
			level++;
			DisableAll ();
			Enable ();
			return true;
		} else {
			return false;
		}

	}

	public void SetMesh(Mesh icon){
		transform.GetChild (0).GetComponent<MeshFilter> ().mesh = icon;

	}


}
