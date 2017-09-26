using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFight : MonoBehaviour {

	public float punchImpact;
	private GameObject player;
	private Energy pe;
    

    void Start(){        
        player = GameObject.FindGameObjectsWithTag("Player")[0];
		pe = (Energy) player.GetComponent(typeof(Energy));
	}


	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.Equals(player))
		{
            pe.LooseEnergy (punchImpact);
		}
	}
}
