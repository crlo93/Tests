using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Boomlagoon.JSON;

public class getPieceMap : MonoBehaviour {

	private string url;
	private MapContent startPosition;
	private MapContent[] mapContent;
	private JSONObject json;

	class MapContent {
		public double lat { get; set; }
		public double lon { get; set; }
	}
		

	// Use this for initialization
	void Start () {
		url = "http://robo-fightworld.bigbang.uno/api/map/get.piece.php";
		getDataGPS ();
		getData ();
	}

	void getDataGPS () {
		startPosition = new MapContent ();
		startPosition.lon = 0;
		startPosition.lat = 0;
		//startPosition.lon = -103.32886f;
		//startPosition.lat = 20.69616f;
		StartCoroutine ("getGPS");
	}

	IEnumerator getGPS() {
		Debug.Log ("getGPS START");
		// First, check if user has location service enabled
		if (!Input.location.isEnabledByUser)
			yield break;

		// Start service before querying location
		Input.location.Start();

		// Wait until service initializes
		int maxWait = 5;
		while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0) {
			yield return new WaitForSeconds(1);
			maxWait--;
		}

		// Service didn't initialize in 20 seconds
		if (maxWait < 1) {
			print("Timed out");
			yield break;
		}

		// Connection has failed
		if (Input.location.status == LocationServiceStatus.Failed) {
			print("Unable to determine device location");
			yield break;
		} else {
			// Access granted and location value could be retrieved
			startPosition.lat = Input.location.lastData.latitude;
			startPosition.lon = Input.location.lastData.longitude;
			print("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);
		}

		// Stop service if there is no need to query location updates continuously
		//Input.location.Stop();
		Debug.Log ("getGPS END");
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
			json = JSONObject.Parse(serviceData);
			if (json == null) {
				Debug.Log ("getJSON NULL");
				Debug.Log("No data converted");
			} else {
				//Debug.Log ("getJSON DONE");
				//Debug.Log (json);
				int lenght = (int) json["LENGTH"].Number;
				mapContent = new MapContent[lenght];
				//Debug.Log (json["DATA"].Array);
				foreach(JSONValue item in json["DATA"].Array) {
					JSONObject data = item.Obj;
					//Debug.Log (item);
					//Debug.Log (data);
					//Debug.Log (data["latitud"]);
					//Debug.Log (data["longitud"]);
					//Debug.Log (data["latitud"].Str);
					//Debug.Log (data["longitud"].Str);

					//float ltR = float.Parse(data["latitud"].Str) * Mathf.Deg2Rad; 
					//float lnR = float.Parse(data["longitud"].Str) * Mathf.Deg2Rad; 
					//float _radius = 100f;
					//float xPos = (_radius) * Mathf.Cos(ltR) * Mathf.Cos(lnR);
					//float zPos = (_radius) * Mathf.Cos(ltR) * Mathf.Sin(lnR);
					//float yPos = (_radius) * Mathf.Sin(ltR);

					float lt = (float) float.Parse (data ["latitud"].Str) - (float) startPosition.lat;
					float ln = (float) float.Parse (data["longitud"].Str) - (float) startPosition.lon;

					lt *= 10000;
					ln *= 10000;

					//float ltR = (float) float.Parse (data ["latitud"].Str) * Mathf.Deg2Rad; 
					//float lnR = (float) float.Parse (data ["longitud"].Str) * Mathf.Deg2Rad; 
					//float _radius = 1000000f;
					//float xPos = (_radius) * Mathf.Cos(ltR) * Mathf.Cos(lnR);
					//float zPos = (_radius) * Mathf.Cos(ltR) * Mathf.Sin(lnR);
					//float yPos = (_radius) * Mathf.Sin(ltR);

					GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
					cube.AddComponent<Rigidbody>();
					cube.AddComponent<PieceInfo>();
					PieceInfo pI = cube.GetComponent<PieceInfo>();
					pI.idMap = data ["idMap"].Str;
					pI.idPartMap = data ["id_partMap"].Str;
					cube.GetComponent<Rigidbody>().useGravity = false;
					cube.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY;
					//cube.transform.position = new Vector3(xPos, 1, zPos);
					cube.transform.position = new Vector3(lt, 1, ln);

					//cube.transform.position = new Vector3(xPos, 1, zPos);


					//Debug.Log (xPos);
					//Debug.Log (zPos);

					//Debug.Log (lt);
					//Debug.Log (ln);
				}
			}
		} else {
			Debug.Log ("getJSON ERROR");
			Debug.Log(www.error);
		}
		Debug.Log ("getDataEnumerator END");
	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.name == "Cube"){
			Debug.Log (col);
			//AddPiece to User
		}
	}

}
