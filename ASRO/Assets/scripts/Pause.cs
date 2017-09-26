using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

	public Texture flickerTexture;
	public bool isPause;
	void Start()
	{
//		Debug.Log ("huhu");
		isPause = false;
	}
	void Update()
	{
		if(Input.GetKeyDown (KeyCode.Escape) || Input.GetButtonDown ("X360_Start")) {
			Debug.Log ("huhu");
			if (!isPause) 
			{
				Time.timeScale = 0;
				MuteEnemies (true);
				isPause = true;
			}else{
				Time.timeScale = 1;
				MuteEnemies (false);

				isPause = false;
			}
		} 
	}


	void OnGUI() {
		if(isPause){
			int seed = Time.renderedFrameCount % Random.Range (1, 10);
			switch(seed){
			case 1:
				GUI.DrawTexture (new Rect (Screen.width, 0, -Screen.width, Screen.height), flickerTexture);
				break;
			case 2:
				GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), flickerTexture);
				break;
			case 3:
				GUI.DrawTexture (new Rect (0, Screen.height, Screen.width, -Screen.height), flickerTexture);
				break;
			case 4:
				GUI.DrawTexture (new Rect (Screen.width, Screen.height, -Screen.width, -Screen.height), flickerTexture);
				break;
			default:
				break;
			}

//			if (Time.renderedFrameCount % Random.Range (5, 10) > 0) {
//				GUI.DrawTexture (new Rect (Screen.width, 0, -Screen.width, Screen.height), flickerTexture);
//			}
////			else {
////				GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), flickerTexture);
////			}

		}
	}

	private void MuteEnemies(bool toggle){
		foreach (GameObject e in GameObject.FindGameObjectsWithTag ("Enemy")) {
			e.GetComponent<AudioSource> ().mute = toggle;
		}

	}
}