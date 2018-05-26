using UnityEngine;
using System.Collections;

public class GPS : MonoBehaviour {

	private float latitude = 0.0F;
	private float longitude = 0.0F;
	private string message = "";

	public IEnumerator Start() {
		// First, check if user has location service enabled
		if (!Input.location.isEnabledByUser)
			yield break;

		// Start service before querying location
		Input.location.Start();

		// Wait until service initializes
		int maxWait = 20;
		while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0) {
			yield return new WaitForSeconds(1);
			maxWait--;
		}

		// Service didn't initialize in 20 seconds
		if (maxWait < 1) {
			message = "Timed out";
			yield break;
		}

		// Connection has failed
		if (Input.location.status == LocationServiceStatus.Failed) {
			message = "Unable to determine device location";
			yield break;
		} else {
			latitude = Input.location.lastData.latitude;
			longitude = Input.location.lastData.longitude;
			// Access granted and location value could be retrieved
			message = "Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp;
		}

		// Stop service if there is no need to query location updates continuously
		Input.location.Stop();
	}

	public string getMessage() {
		return message;
	}

}