using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Views {EXPLORE,  FRAG};  

public class ViewSwitch : MonoBehaviour {



	public Camera explorerView;
	public Camera fragView;
	private Camera[] cameras;
	private int currentCamIndex = 0;

    private Texture2D fragViewTint;
    public Color fragViewTintColor;

	Views status;

	public AudioClip sound;
	private AudioSource ac;

    void Start() {
		ac = GetComponent<AudioSource> ();
		cameras = new Camera[]{ explorerView, fragView};

		cameras [0].backgroundColor = Color.black;
		cameras [1].backgroundColor = Color.black;
		//cameras [2].backgroundColor = Color.black;

		cameras [0].cullingMask = (1 << LayerMask.NameToLayer("ExplorerViewLayer"));
		//cameras [1].cullingMask = (1 << LayerMask.NameToLayer("EnemiesViewLayer"));
		//cameras [2].cullingMask = (1 << LayerMask.NameToLayer("FragView"));
		//cameras [1].cullingMask = (1 << LayerMask.NameToLayer("FragView"));

		SwitchCamera ();
        
    }

	void Update() {

		//change color
		if (Input.GetKeyDown("2")){
			ColorIndexUp();
		}
		if (Input.GetKeyDown("1")){
			ColorIndexDown();
		}

        //mouse
        if (Input.GetAxis("Mouse ScrollWheel") < 0) {
            //print(Input.GetAxis("Mouse ScrollWheel"));
            ColorIndexUp();
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            print(Input.GetAxis("Mouse ScrollWheel"));
            ColorIndexDown();
        }

        //controller
        //change color
        if (Input.GetButtonDown("X360_R_Bumper")) { 
			if(!transform.GetComponent<SkillzzzBooster>().HUDorMapActive()){
				ColorIndexUp();}
			}
		if (Input.GetButtonDown("X360_L_Bumper")) {
			if (!transform.GetComponent<SkillzzzBooster> ().HUDorMapActive ()) {
				ColorIndexDown ();
			}
		}


        //color light for frag view

		if (currentCamIndex == (int)Views.FRAG)
        {
            gameObject.transform.GetChild(0).gameObject.transform.Find("PlayerLight").GetComponent<Light>().color = fragViewTintColor;
			GetComponent<Move> ().SetCurrentSpeed (.5f);
        }
        else {
            gameObject.transform.GetChild(0).gameObject.transform.Find("PlayerLight").GetComponent <Light>().color = new Color(1,1,1);
        }

	}

    private void ColorIndexUp(){
		currentCamIndex++;
		if (currentCamIndex > cameras.Length - 1) { currentCamIndex = 0; }
		SwitchCamera ();
		//print(cameras[currentCamIndex].backgroundColor);
	}

	private void ColorIndexDown(){
		currentCamIndex--;
		if (currentCamIndex < 0) { currentCamIndex = cameras.Length - 1; }
		SwitchCamera ();
		print(cameras[currentCamIndex].backgroundColor.ToString());
	}

	private void SwitchCamera(){
		
		foreach(Camera c in cameras){
			c.enabled = false;
		}
		cameras [currentCamIndex].enabled = true;
		status = (Views)currentCamIndex;
		Debug.Log (status);
		ac.clip = sound;
		ac.Play ();
	}

	public Views GetStatus(){
		return status;
	}


}
