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
	[SyncVar (hook="hpBarChange")] public float Health= 100;
	private float maxhealth= 100;
	private bool canJump;
	private int jumps;
	private int attacks;
	private int defense=1;
	private float xAngles, yAngles, zAngles;
	public GameObject powerPrefab;
	private Transform powerTr;
	protected Joystick joystick;
	protected Button btnAction,btnDefense;
	private Rigidbody rb;
	private Transform tr;
	private Animator anHead,anBody,anLarm,anRarm,anLegs;
	private GroundbullLeft scLarm;
	private GroundbullRight scRarm;
	private GroundbullLegs scLegs;
	private GameObject head,body,larm,rarm,legs,headO,bodyO,larmO,rarmO,legsO;
	private Image hp1, hp2;
	private Color hpverde;
	private GameObject[] respawns;
	private GameObject[] hpbars;
	private GameObject startRobot,serverRobot,HpBarPlayer2,robotHead,robotBody,robotLeft,robotRight,robotLegs,imageHp1;

	public override void OnStartLocalPlayer() {		
		btnAction = GameObject.FindGameObjectWithTag("btnaction").GetComponent<Button>();
		btnDefense = GameObject.FindGameObjectWithTag("btndefense").GetComponent<Button>();
		btnAction.onClick.AddListener(attack);
		btnDefense.onClick.AddListener(defend);
		anHead = robotHead.GetComponent<Animator> ();
		anBody = robotBody.GetComponent<Animator> ();
		anLarm = robotLeft.GetComponent<Animator> ();
		anRarm = robotRight.GetComponent<Animator> ();
		anLegs = robotLegs.GetComponent<Animator> ();
		scLarm = robotLeft.GetComponent<GroundbullLeft> ();
		scRarm = robotRight.GetComponent<GroundbullRight> ();
		scLegs = robotLegs.GetComponent<GroundbullLegs> ();
		scLarm.enabled=!scLarm.enabled;
		scRarm.enabled=!scRarm.enabled;
		scLegs.enabled=!scLegs.enabled;
		hp1 = imageHp1.GetComponent<Image> ();
		xAngles = 180;
		yAngles = 0;
		zAngles = 0;
		jumps = 2;
		attacks = 0;
		canJump = true;
		rb = startRobot.GetComponent<Rigidbody> ();
		tr = startRobot.GetComponent<Transform>();
		hpverde = hp1.color;	
	}

	public override void OnStartServer() {
	}
	public override void OnStartClient(){
		respawns = GameObject.FindGameObjectsWithTag("Robot");
		joystick= FindObjectOfType<Joystick>();	
		startRobot = respawns[respawns.Length-1];
		imageHp1 = GameObject.FindGameObjectWithTag("Hp1");
		//HEAD
		string robotHeadPath = "Groundbull"; // Take from data base active robot
		robotHead = Instantiate(Resources.Load("Robot/"+robotHeadPath+"/Head", typeof(GameObject)),startRobot.transform.position,Quaternion.identity) as GameObject;
		robotHead.transform.parent = startRobot.transform;
		//BODY
		string robotBodyPath = "Groundbull"; // Take from data base active robot
		robotBody = Instantiate(Resources.Load("Robot/"+robotBodyPath+"/Body", typeof(GameObject)),startRobot.transform.position,Quaternion.identity) as GameObject;
		robotBody.transform.parent = startRobot.transform;
		//LEFT
		string robotLeftPath = "Groundbull"; // Take from data base active robot
		robotLeft = Instantiate(Resources.Load("Robot/"+robotLeftPath+"/Left", typeof(GameObject)),startRobot.transform.position,Quaternion.identity) as GameObject;
		robotLeft.transform.parent = startRobot.transform;
		//RIGHT
		string robotRightPath = "Groundbull"; // Take from data base active robot
		robotRight = Instantiate(Resources.Load("Robot/"+robotRightPath+"/Right", typeof(GameObject)),startRobot.transform.position,Quaternion.identity) as GameObject;
		robotRight.transform.parent = startRobot.transform;
		//LEGS
		string robotLegsPath = "Groundbull"; // Take from data base active robot
		robotLegs = Instantiate(Resources.Load("Robot/"+robotLegsPath+"/Legs", typeof(GameObject)),startRobot.transform.position,Quaternion.identity) as GameObject;
		robotLegs.transform.parent = startRobot.transform;		
		if (respawns.Length > 1) {
			//Conecto un cliente
			Debug.Log ("Se conecto el jugador 2");	
			hpbars = GameObject.FindGameObjectsWithTag("HpBar");
			Debug.Log (hpbars.Length);	
			HpBarPlayer2=hpbars[hpbars.Length-1];
			HpBarPlayer2.transform.position=new Vector3(1000,750,0);
			startRobot.name = "RobotLocal2";
		} 
		else if (respawns.Length > 0)
		{
			Debug.Log ("Se conecto el jugador 1");
			startRobot.name = "RobotLocal";
		}
	}
	    
	
	// Update is called once per frame
	void Update () {
		if (!isLocalPlayer || rb==null)
		{
			return;
		}
		rb.velocity = new Vector2 (joystick.Horizontal*10f,rb.velocity.y);
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
			rb.velocity = new Vector2 (0f,rb.velocity.y);
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

	void jumpRobot() {
		anLegs.SetBool("Defend", false);
		anHead.SetBool("Down", false);
		anBody.SetBool("Down", false);
		anLarm.SetBool("Down", false);
		anRarm.SetBool("Down", false);
		anLegs.SetBool("Down", false);
		forceJump = 0f;
		if (canJump && jumps>0) { // To Jump
			rb.velocity = Vector3.zero;
			forceJump = jump;
			jumps--;
			if (jumps == 0)
			{
				forceJump += jump/2;
			}
			anLegs.SetTrigger("Jump");
		}
		Vector3 movement = new Vector3 (forceDash*Time.deltaTime, forceJump, 0f);
		rb.AddForce(movement * speed);
	}

	void OnCollisionExit (Collision collision) {		
	}
	
	void OnCollisionEnter (Collision collision) {		
		if (isLocalPlayer)
		{
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
					Debug.Log(contact.otherCollider.name);
					canJump = true;
					jumps = 1;
				}
			}
		}
		else
		{
			int haydaño=1;
			foreach (ContactPoint contact in collision.contacts) {
				//rb.angularVelocity = Vector3.zero;
				if (contact.otherCollider.name == "Piso") 
				{

				}else 
				{
					haydaño=0;
				}
			}
		}
	}

	[Command]
	void CmdPowerShoot()
	{
		GameObject power = (GameObject) Instantiate(powerPrefab as GameObject,new Vector3((tr.position.x-(xAngles/90)),tr.position.y,tr.position.z),tr.rotation);
		power.GetComponent<Transform>().Rotate (0,270,0);
		power.GetComponent<Rigidbody>().velocity=power.transform.forward * 20.0f;
		//spawn the bullet on the clients
		NetworkServer.Spawn(power);
		Destroy(power,1f);
	}

	public void hpBarChange(float health)
	{
		float ratio = health/ maxhealth; 
		if (health< 1)
			Destroy(gameObject);
		else if (health< 20)
			hp1.color = Color.red;
		else if (health< 50)
			hp1.color = Color.yellow;
		else
			hp1.color = hpverde;
		hp1.rectTransform.localScale = new Vector3 (ratio, 1, 1);
	}

	public void takedamage(float damage)
	{
		if(!isServer)
			return;
		Health-= damage;
		if (Health< 0)
			Health= 0;
		hpBarChange (Health);
	}

	public void healdamage(float damage)
	{
		Health+= damage;
		if (Health> 100)
			Health= 100;
		hpBarChange (Health);
	}

	public void attack() 
	{	
		defense=1;	
		if (attacks == 0) {
			attacks++;
		} 
		else if (attacks == 1) {
			attacks++;
		} 
		else {
			// CmdPowerShoot();
			attacks = 0;
		}
	}

	public void defend()
	{
		defense=10;
		Vector3 movement = new Vector3 (0f, 0f, 0f);
		rb.AddForce(movement * speed);
	}

}
