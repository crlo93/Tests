﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;


public class GroundbullLegs : NetworkBehaviour {

	protected Animator anLegs;
	protected Button btnAction,btnDefense;
	private int attacks;

	// Use this for initialization
	void Start () {	
		anLegs = GetComponent<Animator> ();
		btnAction = GameObject.FindGameObjectWithTag("btnaction").GetComponent<Button>();
		btnAction.onClick.AddListener(movement);
		attacks = 0;
	}

	void movement()
	{
		anLegs.SetBool ("Defend", false);
		if (attacks == 0) {
			attacks++;
		} else if (attacks == 1) {
			attacks++;
		} else {
			if(anLegs.GetBool("Down")==true)
				anLegs.SetTrigger ("Attack Down");
			else
				anLegs.SetTrigger ("Attack");
			attacks = 0;
		}
	}

	// Update is called once per frame
	void Update () {
	}
}
