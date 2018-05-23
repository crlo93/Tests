using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OcealyndeLegs : MonoBehaviour {

	protected Animator anLegs;
	protected Button btnAction,btnDefense;
	private int attacks;
	public Text textBlock;

	// Use this for initialization
	void Start () {
		anLegs = GetComponent<Animator> ();
		textBlock= FindObjectOfType<Text>();
		btnAction = GameObject.FindGameObjectWithTag("btnaction").GetComponent<Button>();
		btnDefense = GameObject.FindGameObjectWithTag("btndefense").GetComponent<Button>();
		btnAction.onClick.AddListener(movement);
		btnDefense.onClick.AddListener(defense);
		attacks = 0;
	}

	void defense()
	{
		anLegs.SetBool ("Defend", true);
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
