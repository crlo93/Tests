using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class RobotMovement : NetworkBehaviour {
	
	private float speed = 10f;
	private float jump = 30f;
	private float forceJump = 0f;
	private float forceDash = 0f;
	public float hp = 100;
	private float maxHp = 100;
	private bool canJump;
	private int jumps;
	private int attacks;
	public float xAngles, yAngles, zAngles;
	protected Joystick joystick;
	private Rigidbody rb;
	private Transform tr;
	private Animator anHead,anBody,anLarm,anRarm,anLegs; 
	private Animator anHead1,anBody1,anLarm1,anRarm1,anLegs1; 
	private GameObject head,body,larm,rarm,legs,headO,bodyO,larmO,rarmO,legsO;
	private Image hp1, hp2;
	private Color hpverde;
	private GameObject[] respawns;
	private GameObject startRobot;

	public override void OnStartServer() {
		respawns = GameObject.FindGameObjectsWithTag ("Robot");
		startRobot = respawns[respawns.Length-1];
		GameObject imageHp1 = GameObject.FindGameObjectWithTag("Hp1");
		//HEAD
		string robotHeadPath = "Ocealynde"; // Take from data base active robot
		GameObject robotHead = Instantiate(Resources.Load("Robot/"+robotHeadPath+"/Head", typeof(GameObject))) as GameObject;
		robotHead.transform.parent = startRobot.transform;
		//BODY
		string robotBodyPath = "Ocealynde"; // Take from data base active robot
		GameObject robotBody = Instantiate(Resources.Load("Robot/"+robotBodyPath+"/Body", typeof(GameObject))) as GameObject;
		robotBody.transform.parent = startRobot.transform;
		//LEFT
		string robotLeftPath = "Ocealynde"; // Take from data base active robot
		GameObject robotLeft = Instantiate(Resources.Load("Robot/"+robotLeftPath+"/Left", typeof(GameObject))) as GameObject;
		robotLeft.transform.parent = startRobot.transform;
		//RIGHT
		string robotRightPath = "Ocealynde"; // Take from data base active robot
		GameObject robotRight = Instantiate(Resources.Load("Robot/"+robotRightPath+"/Right", typeof(GameObject))) as GameObject;
		robotRight.transform.parent = startRobot.transform;
		//LEGS
		string robotLegsPath = "Ocealynde"; // Take from data base active robot
		GameObject robotLegs = Instantiate(Resources.Load("Robot/"+robotLegsPath+"/Legs", typeof(GameObject))) as GameObject;
		robotLegs.transform.parent = startRobot.transform;

		anHead = robotHead.GetComponent<Animator> ();
		anBody = robotBody.GetComponent<Animator> ();
		anLarm = robotLeft.GetComponent<Animator> ();
		anRarm = robotRight.GetComponent<Animator> ();
		anLegs = robotLegs.GetComponent<Animator> ();
		joystick= FindObjectOfType<Joystick>();		
		hp1 = imageHp1.GetComponent<Image> ();
		xAngles = 180;
		yAngles = 0;
		zAngles = 0;
		jumps = 2;
		attacks = 0;
		canJump = true;
		rb = startRobot.GetComponent<Rigidbody> ();
		tr = startRobot.GetComponent<Transform>();
		hpverde = hp1.color;startRobot.name = "RobotLocal";
		//Debug.Log (isClient);
		Debug.Log("OnStartLocalPlayer");
	}

	public override void OnStartServer() {

		respawns = GameObject.FindGameObjectsWithTag("Robot");
		Debug.Log (respawns.Length);
		if (respawns.Length>1) {
			//Conecto un cliente
			Debug.Log("Se conecto un cliente");
			//Aquí se envia las partes del robot del host al cliente.

		}

	}
	// Update is called once per frame
	void Update () {
		if (!isLocalPlayer)
		{
			return;
		}

		var rigidbody = GetComponent<Rigidbody> ();
		rigidbody.velocity = new Vector2 (joystick.Horizontal*10f,rigidbody.velocity.y);
		if (joystick.Vertical > .75) {//Brincar
			anHead.SetBool("Down", false);
			anBody.SetBool("Down", false);
			anLarm.SetBool("Down", false);
			anRarm.SetBool("Down", false);
			anLegs.SetBool("Down", false);
			jumpRobot();
			canJump = false;
		} 
		else if(joystick.Vertical > -.5) {//caminar-Girar
			anHead.SetBool("Down", false);
			anBody.SetBool("Down", false);
			anLarm.SetBool("Down", false);
			anRarm.SetBool("Down", false);
			anLegs.SetBool("Down", false);
			if (joystick.Horizontal < -.5) {
				if (xAngles != 180) {
					xAngles = 180;
					tr.Rotate (yAngles, xAngles / 2, zAngles);
					tr.Rotate (yAngles, xAngles / 2, zAngles);
				}
			}
			else if(joystick.Horizontal > .5)
			{
				if (xAngles != -180) {
					xAngles = -180;
					tr.Rotate (yAngles, xAngles / 2, zAngles);
					tr.Rotate (yAngles, xAngles / 2, zAngles);
				}
			}
			if (jumps > 0)
				canJump = true;
		} 
		else if(joystick.Vertical < -.75 && jumps==2)//Agacharse
		{
			anHead.SetBool("Down", true);
			anBody.SetBool("Down", true);
			anLarm.SetBool("Down", true);
			anRarm.SetBool("Down", true);
			anLegs.SetBool("Down", true);
			rigidbody.velocity = new Vector2 (0f,rigidbody.velocity.y);
			takedamage (1);
		}
		else {
			anHead.SetBool("Down", false);
			anBody.SetBool("Down", false);
			anLarm.SetBool("Down", false);
			anRarm.SetBool("Down", false);
			anLegs.SetBool("Down", false);
			anLegs.SetBool("Defend", false);
			if (jumps > 0)
				canJump = true;
		}
	}

	public void hpBarChange()
	{
		float ratio = hp / maxHp; 
		if (hp < 20)
			hp1.color = Color.red;
		else if (hp < 50)
			hp1.color = Color.yellow;
		else
			hp1.color = hpverde;
		hp1.rectTransform.localScale = new Vector3 (ratio, 1, 1);
	}

	public void takedamage(float damage)
	{
		hp -= damage;
		if (hp < 0)
			hp = 0;
		hpBarChange ();
	}

	public void healdamage(float damage)
	{
		hp += damage;
		if (hp > 100)
			hp = 100;
		hpBarChange ();
	}

	public void attack() 
	{
	}

	public void defend()
	{
		Vector3 movement = new Vector3 (0f, 0f, 0f);
		rb.AddForce(movement * speed);
	}

	void jumpRobot() {
		anLegs.SetBool("Defend", false);
		anHead.SetBool("Down", false);
		anBody.SetBool("Down", false);
		anLarm.SetBool("Down", false);
		anRarm.SetBool("Down", false);
		anLegs.SetBool("Down", false);
		healdamage (1);
		forceJump = 0f;
		if (canJump && jumps>0) { // To Jump
			rb.velocity = Vector3.zero;
			forceJump = jump;
			jumps--;
			if (jumps == 0)
				forceJump += jump/2;
			anLegs.SetTrigger("Jump");
		}
		Vector3 movement = new Vector3 (forceDash*Time.deltaTime, forceJump, 0f);
		rb.AddForce(movement * speed);
	}

	void OnCollisionEnter (Collision collision) {
		foreach (ContactPoint contact in collision.contacts) {
			//rb.angularVelocity = Vector3.zero;
			if (contact.otherCollider.name == "Piso") {
				canJump = true;
				jumps = 2;
			} else if (jumps < 1) {
				canJump = false;
				jumps = 0;
			}else 
			{
				canJump = true;
				jumps = 1;
			}
		}
	}

	void OnCollisionExit (Collision collision) {
		
	}
}
