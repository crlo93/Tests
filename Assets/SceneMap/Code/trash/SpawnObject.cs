using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour {

	public Transform SpawnPoint;
	public Rigidbody ObjectToClone;

	void Update () {
		if (Input.GetKeyDown("space")) {
			float x = SpawnPoint.position.x + Random.Range(1,10);
			float y = SpawnPoint.position.y;
			float z = SpawnPoint.position.z + Random.Range(1,10);
			SpawnPoint.position = new Vector3 (x,y,z);
			Instantiate (ObjectToClone, SpawnPoint.position, SpawnPoint.rotation);
		}
	}

}
