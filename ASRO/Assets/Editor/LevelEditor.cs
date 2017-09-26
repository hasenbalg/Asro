using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(LevelBuilder2))]
public class LevelEditor : Editor {
	//https://www.youtube.com/watch?v=fja14SIwRQQ
	public override void OnInspectorGUI(){
		base.OnInspectorGUI ();
		if(GUILayout.Button("REgenerate The MAP!!!!!!!")){
			LevelBuilder2 buildMap  = (LevelBuilder2) target;
			buildMap.BuildLevel ();
		}
	}

}
