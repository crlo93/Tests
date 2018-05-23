using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerRobot : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Alpha1)) {
			GameObject head = GameObject.Find ("Head");
			ChangePrefab cp = head.GetComponent<ChangePrefab> ();
			cp.setPrefab (0,0);
			//Debug.Log("1");
		}
		if (Input.GetKeyDown(KeyCode.Alpha2)) {
			GameObject head = GameObject.Find ("Head");
			ChangePrefab cp = head.GetComponent<ChangePrefab> ();
			cp.setPrefab (0,1);
			//Debug.Log("2");
		}
		if (Input.GetKeyDown(KeyCode.Alpha3)) {
			GameObject head = GameObject.Find ("Head");
			ChangePrefab cp = head.GetComponent<ChangePrefab> ();
			cp.setPrefab (1,0);
			//Debug.Log("3");
		}
		if (Input.GetKeyDown(KeyCode.Alpha3)) {
			GameObject head = GameObject.Find ("Head");
			ChangePrefab cp = head.GetComponent<ChangePrefab> ();
			cp.setPrefab (1,1);
			//Debug.Log("4");
		}
		if (Input.GetKeyDown(KeyCode.Backspace)) {
			SceneManager.LoadScene ("Fight");
		}
	}
}
