using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlataform : MonoBehaviour {

	//STATIC
	private int RETRASO = 0;

	private bool goRight = true;
	private int contadorRetraso;

	void Start() {
		contadorRetraso = RETRASO;
	}
	
	void FixedUpdate () {
		if (contadorRetraso > 0) {
			contadorRetraso--;
			if (goRight) {
				if (transform.position.x < -10) {
					goRight = false;
				}
				transform.Translate (Vector3.left);
			} else {
				if (transform.position.x > 0) {
					goRight = true;
				}
				transform.Translate(Vector3.right);
			}
		} else {
			contadorRetraso = RETRASO;
		}
	}

}
