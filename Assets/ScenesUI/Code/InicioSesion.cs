using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
// using Assets.ScenesUI.Code.Message;

public class InicioSesion : MonoBehaviour {

	public Text nickName;
	public InputField password;
	private String mssg = "";
	private String ttl = "";
	private bool showPopUp = false;

	public void Start() {
		int id = PlayerPrefs.GetInt("id", 0);
		if (id!=0) {
			MenuPrincipal mP = new MenuPrincipal();
			mP.Mapa();
		}
	}

	public void login() {

		Debug.Log(nickName.text);
		Debug.Log(password.text);

		StartCoroutine(checkLogin());
	}

	private IEnumerator checkLogin() {

		WWWForm iForm = new WWWForm();
		iForm.AddField("userName", nickName.text);
		iForm.AddField("password", password.text);
		string url = "http://robo-fightworld.bigbang.uno/api/login/login_usuario.php";
		WWW www = new WWW(url, iForm);
		yield return www;

		Debug.Log(www.text);

		int id = 0;
		int.TryParse(www.text, out id);

		try {
			PlayerPrefs.SetInt("id",id);
		} catch (System.Exception err){
			Debug.Log("E: " + err);
		}

		if (id > 0) {
			Debug.Log("Correct");
			MenuPrincipal mP = new MenuPrincipal();
			mP.Mapa();
		} else {
			this.alert("Inicio de sesion","Usuario o contraseña incorrecto");
			Debug.Log("NoCorrect");
		}

	}

	public void alert(String ttl,String mssg) {
		this.mssg = mssg;
		this.ttl = ttl;
		showPopUp = true;
	}

	public void OnGUI() {
		if (showPopUp) {
			GUI.Window(0, new Rect((Screen.width / 2) - 150, (Screen.height / 2) - 75, 300, 150), ShowGUI, this.ttl);
		}
	}

	public void ShowGUI(int windowID) {
		// You may put a label to show a message to the player

		GUI.Label(new Rect(65, 40, 200, 30), this.mssg);

		// You may put a button to close the pop up too

		if (GUI.Button(new Rect(50, 80, 75, 30), "OK")) {
			showPopUp = false;
			// you may put other code to run according to your game too
		}

	}

}
