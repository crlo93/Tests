using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class InicioSesion : MonoBehaviour {

	public Text nickName;
	public Text password;

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
			Debug.Log("NoCorrect");
		}

	}

}
