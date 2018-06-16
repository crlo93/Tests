using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;
using UnityEngine.UI;
using System;

public class Registro : MonoBehaviour {

	public GameObject username;
	public GameObject email;
	public GameObject password;
	public GameObject confpassword;
	private string Username;
	private string Email;
	private string Password;
	private string ConfPassword;
	private string form;
	//private Text saveText;
	//private Text displayText;
	private bool EmailValid = false;

	public void Regis(){
		SceneManager.LoadScene("Registro");
	}

	public void Bien(){
		SceneManager.LoadScene("InicioSesion");
	}

	public void RegistroButton () {
		//bool UN = false;
		//bool EM = false;
		//bool PW = false;
		//bool CP = false;
		if (Username != "") {
		} else {
			Debug.LogWarning ("Campo obligatorio");
		}
		if (Email != "") {
			if (EmailValid) {
				if (Email.Contains ("@")) {
					if (Email.Contains (".")) {
					} else {
						Debug.LogWarning ("Correo Incorrecto");
					}
				} else {
					Debug.LogWarning ("Correo Incorrecto");
				}
			}
		} else {
			Debug.LogWarning ("Campo obligatorio");
		}
		if (Password != "") {
			if (Password.Length > 5) {
			} else {
				Debug.LogWarning ("Contraseña debe ser al menos 6 caracteres");
			}
		} else {
			Debug.LogWarning ("Campo obligatorio");
		}
		if (ConfPassword != "") {
			if (ConfPassword == Password) {
			} /*else {
				Debug.LogWarning ("Contraseña no coincide");
				}*/
			} else {
				Debug.LogWarning ("Campo obligatorio");
			}
			string url = "http://robo-fightworld.bigbang.uno/api/registro/registro_usuario.php";

			WWWForm formDate = new WWWForm ();
			formDate.AddField ("table", "user");
			formDate.AddField ("usr_nick", Username);
			formDate.AddField ("usr_email", Email);
			formDate.AddField ("usr_password", Password);

			WWW www = new WWW (url, formDate);
			StartCoroutine (request (www));
		}

		void Update (){
			if (Input.GetKeyDown (KeyCode.Return)) {
				if (Username != "" && Email != "" && Password != "" && ConfPassword != "") {
					RegistroButton ();
				}
			}
			Username = username.GetComponent<InputField> ().text;
			Email = email.GetComponent<InputField> ().text;
			Password = password.GetComponent<InputField> ().text;
			ConfPassword = confpassword.GetComponent<InputField> ().text;
		}

		// Update is called once per frame
		IEnumerator request	(WWW www) {
			yield return www;
			//displayText.text = www.text;
			//saveText.text = www.text;
			Bien();
		}
		
	}
