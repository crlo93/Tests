using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageDragandDrop : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Drag() {

        GameObject.Find("Image").transform.position = Input.mousePosition;
        print("We are dragging the Mouse");
    }

    public void Drop() {
      
        GameObject ph1 = GameObject.Find("Placeholder");
        float distance = Vector3.Distance(GameObject.Find("Image").transform.position, ph1.transform.position);
        if (distance < 170) {

            GameObject.Find("Image").transform.position = ph1.transform.position;
                print("here");
        }
    
    }

    }

