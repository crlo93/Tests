using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSphere_Key : MonoBehaviour {

	public float speed = 25.0F;

	private Vector3 moveDirection;

	public void Start() {
		moveDirection = Vector3.zero;
	}

	public void Update () {
		CharacterController controller = GetComponent<CharacterController> ();
		moveDirection = new Vector3 (Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
		moveDirection = transform.TransformDirection (moveDirection);
		moveDirection *= speed;
		controller.Move (moveDirection * Time.deltaTime);
	}
}
