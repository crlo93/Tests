using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayPre : MonoBehaviour {

	public InputField Nickname;
	public Text Salida;

	void Start() {
		Salida.text = PlayerPrefs.GetString ("Username");
	}

	public void guardar(){
		PlayerPrefs.SetString ("Username", Nickname.text);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
