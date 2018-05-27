using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mapbox.Utils;
using Mapbox.Unity.Utilities;

public class MoveShpere_GPS : MonoBehaviour {

	public Text location;

	private Vector2d getLatLon;
	private CharacterController controller;
	private float speed = 10.0F;
	public GPS gps;
	private Vector3 moveDirection;

	public void Start() {
		controller = GetComponent<CharacterController> ();
		moveDirection = Vector3.zero;
	}

	public void Update() {
		location.text = gps.getMessage();
		moveDirection = new Vector3 (Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
		moveDirection = transform.TransformDirection (moveDirection);
		moveDirection *= speed;
		controller.Move (moveDirection * Time.deltaTime);
	}

}
