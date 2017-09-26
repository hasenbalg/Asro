using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Skillz{
Speed,
	Light,
	Map
};

public class HUDManager: MonoBehaviour{

	private bool isActive = true;
	public GameObject skillTemplate;
	public float verticalDistance = 2f;

	[Range (0, 5)]
	private int maxAvailable = 5;
	public int available;
	public Material bright, dark, highlight;

	private int currentHighlightSkill;

	Transform HUDavailable;
	GameObject[] skillLabels;

	private double lastTriggered;

	public Mesh[] icons;

	private Light spot;
	public float lightIntensity;

	private int lastAvailable = 0;

	void Start (){

		string[] skillz = System.Enum.GetNames (typeof(Skillz));
		skillLabels = new GameObject[skillz.Length];
		for (int i = 0; i < skillz.Length; i++) {
			GameObject skill = Instantiate (skillTemplate,Vector3.right * i * verticalDistance,Quaternion.identity);
			skill.name = "HUD" + System.Enum.GetName(typeof(Skillz), i) + "Bars";
			skill.transform.SetParent (transform, false);
			skill.GetComponent<SkillLevels> ().SetMesh (icons[i]);
			skillLabels [i] = skill;
		}

		spot = (Light)transform.Find ("HUDLight").gameObject.GetComponent<Light>();

		//enable available points

		HUDavailable = transform.Find("HUDAvailable").transform;

		ProvideMaterialToPoints ();

		currentHighlightSkill = (int)Skillz.Speed;
		lastTriggered = Time.realtimeSinceStartup;
		Mark ();
		ToggleHUD ();

	}
	
	// Update is called once per frame
	void Update (){
		if (lastTriggered + .3 < Time.realtimeSinceStartup && isActive) {
				
			if (Input.GetAxis ("Horizontal") > 0 && currentHighlightSkill < skillLabels.Length - 1) {
				//Debug.Log (Time.realtimeSinceStartup - currentHighlightSkill);

				currentHighlightSkill++;
				Mark ();
			} else if (Input.GetAxis ("Horizontal") < 0 && currentHighlightSkill > 0) {
				currentHighlightSkill--;
				Mark ();
			}

			if((Input.GetButton("X360_A") || Input.GetKey(KeyCode.Space)) && available > 0){

				if(skillLabels [currentHighlightSkill].GetComponent<SkillLevels> ().LevelUp ()){
					available--;
				}

			}
			lastTriggered = Time.realtimeSinceStartup;
		}

		if (lastAvailable != available) {
			ProvideMaterialToPoints ();
		}
		lastAvailable = available;


			

	}

	private void Mark (){
		foreach (GameObject sl in skillLabels) {
			sl.GetComponent<SkillLevels> ().Deselect ();
		}
		skillLabels [currentHighlightSkill].GetComponent<SkillLevels> ().Select ();


	}

	private void ProvideMaterialToPoints(){
		for (int i = 0; i < HUDavailable.childCount; i++) {
			if (i < available) {
				HUDavailable.GetChild (i).gameObject.GetComponent<Renderer> ().material = highlight;
			} else {
				HUDavailable.GetChild (i).gameObject.GetComponent<Renderer> ().material = dark;
			}
		}
	}



	public void ToggleHUD(){
		if (isActive) {
			isActive = false;
			ToggelMeshRendererRecursivly (transform, false);
			spot.intensity = 0;
		} else {
			isActive = true;
			ToggelMeshRendererRecursivly (transform, true);
			spot.intensity = lightIntensity;
		}
	}

	private void ToggelMeshRendererRecursivly(Transform root, bool status){
		foreach(Transform child in root){
			if(child.GetComponent<MeshRenderer>() != null){
				child.GetComponent<MeshRenderer> ().enabled = status;
			}
			ToggelMeshRendererRecursivly (child, status);
		}

	}

	public int GetMaxAvailable(){
		return maxAvailable;
	}


	public bool IsActive(){
		return isActive;
	}

	public void AddSkillPoint(){
		if (available < maxAvailable) {
			available++;
		}
	}

}
