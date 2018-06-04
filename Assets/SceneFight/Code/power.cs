using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class power : MonoBehaviour {

		void OnCollisionEnter (Collision colider)
		{
			GameObject hit=colider.gameObject;
			RobotMovement health = hit.GetComponent<RobotMovement>();
			if(health!=null)
			{
				health.takedamage(10);
			}
			Debug.Log(colider);
			// Destroy(gameObject);
		}
}
