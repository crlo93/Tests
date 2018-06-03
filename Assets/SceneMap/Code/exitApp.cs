using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitApp : MonoBehaviour {

	public void exit() {
		Debug.Log("Bye!");
		PlayerPrefs.SetInt("id", 0);
		Application.Quit();
	}

}
