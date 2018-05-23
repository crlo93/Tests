using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OcealyndeRight : MonoBehaviour {

	protected Animator anRarm;
	protected Button btnAction,btnDefense;
	private int attacks;
	public Text textBlock;

	// Use this for initialization
	void Start () {
		anRarm = GetComponent<Animator> ();
		textBlock= FindObjectOfType<Text>();
		btnAction = GameObject.FindGameObjectWithTag("btnaction").GetComponent<Button>();
		btnAction.onClick.AddListener(movement);
		attacks = 0;
	}

	void movement()
	{
		
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
