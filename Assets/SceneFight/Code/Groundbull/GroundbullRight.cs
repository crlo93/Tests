using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;


public class GroundbullRight : NetworkBehaviour {

	protected Animator anRarm;
	protected Button btnAction,btnDefense;
	private int attacks;

	// Use this for initialization
	void Start () {	
		anRarm = GetComponent<Animator> ();
		btnAction = GameObject.FindGameObjectWithTag("btnaction").GetComponent<Button>();
		btnDefense = GameObject.FindGameObjectWithTag("btndefense").GetComponent<Button>();
		btnAction.onClick.AddListener(movement);
		btnDefense.onClick.AddListener(defense);
		attacks = 0;
	}

	void defense()
	{
		anRarm.SetBool ("Defend", true);
	}


	void movement()
	{
		anRarm.SetBool ("Defend", false);
		if (attacks == 0) {
			if(anRarm.GetBool("Down")==true)
				anRarm.SetTrigger ("Attack Down");
			else
				anRarm.SetTrigger ("Attack");
			attacks++;
		} else if (attacks == 1) {
			attacks++;
		} else {
			attacks = 0;
		}

	}

	// Update is called once per frame
	void Update () {
	}
}
