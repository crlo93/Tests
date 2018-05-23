﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OcealyndeLeft : MonoBehaviour {

	protected Animator anLarm;
	protected Button btnAction,btnDefense,btnJump;
	private int attacks;
	public Text textBlock;

	// Use this for initialization
	void Start () {
		anLarm = GetComponent<Animator> ();
		textBlock= FindObjectOfType<Text>();
		btnAction = GameObject.FindGameObjectWithTag("btnaction").GetComponent<Button>();
		btnAction.onClick.AddListener(movement);
		attacks = 0;
	}

	void movement()
	{
		if (attacks == 0) {
			attacks++;
		} else if (attacks == 1) {
			if(anLarm.GetBool("Down")==true)
				anLarm.SetTrigger ("Attack Down");
			else
			anLarm.SetTrigger ("Attack");
			attacks++;
		} else {
			attacks = 0;
		}
	}
		
	// Update is called once per frame
	void Update () {
	}
}
