using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class putNewPiece : MonoBehaviour {

	void OnCollisionEnter(Collision col) {
		Debug.Log("CollisionEnter");
		if (col.gameObject.name == "Cube") {
			Debug.Log (col);
			int id = PlayerPrefs.GetInt("id", 0); //Get id from variable of session user in unity
			PieceInfo pI = col.gameObject.GetComponent<PieceInfo>();
			string url = "http://robo-fightworld.bigbang.uno/api/partUser/get.by.user.php";
			WWWForm iForm = new WWWForm();
			iForm.AddField("idUser", id);
			iForm.AddField("idMap", pI.idMap);
			iForm.AddField("idPartMap", pI.idPartMap);
			WWW www = new WWW(url, iForm);
			StartCoroutine ("putPieceToUser",www);
			// Destroy(col.gameObject);
		}
	}

	private IEnumerator putPieceToUser(WWW www) {
		Debug.Log("~Start putPieceToUser");
		yield return www;
		Debug.Log(www.text);
	}

}
