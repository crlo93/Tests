using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Boomlagoon.JSON;

public class getNickUser : MonoBehaviour {

	public Text setName;
	private string url;

	// Use this for initialization
	void Start () {
		int id = PlayerPrefs.GetInt("id", 0); //Get id from variable of session user in unity
		Debug.Log("id: "+id);
		url = "http://robo-fightworld.bigbang.uno/api/user/get.user.nick.php";
		WWWForm iForm = new WWWForm();
		iForm.AddField("id", id);
		WWW www = new WWW(url, iForm);
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
