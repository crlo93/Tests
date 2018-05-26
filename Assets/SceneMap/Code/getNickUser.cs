using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Boomlagoon.JSON;
using UnityEngine;
using UnityEngine.UI;

public class getNickUser : MonoBehaviour {

	public Text setName;
	private string url;

	// Use this for initialization
	void Start () {
		url = "http://robo-fightworld.bigbang.uno/api/user/get.user.php";
		getData ();
	}

	private void getData() {
		WWW www = new WWW (url);
		StartCoroutine ("getDataEnumerator",www);
	}

	private IEnumerator getDataEnumerator(WWW www) {
		Debug.Log ("getDataEnumerator START");
		yield return www;
		if (www.error == null) {
			string serviceData = www.text;
			JSONObject json = JSONObject.Parse(serviceData);
			if (json == null) {
				Debug.Log ("getJSON NULL");
				Debug.Log("No data converted");
			} else {
				string nick = "";
				foreach(JSONValue item in json["DATA"].Array) {
					JSONObject data = item.Obj;
					nick = data ["usr_nick"].Str;
				}
				setName.text = nick;
			}
		} else {
			Debug.Log ("getJSON ERROR");
			Debug.Log(www.error);
		}
		Debug.Log ("getDataEnumerator END");
	}

}
