using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePrefab : MonoBehaviour {

	public GameObject[] Prefabs;
	public Material[] Materials;

	public void setPrefab(int prefabIndex, int materialIndex) {
		MeshFilter mf = GetComponentInChildren<MeshFilter> ();
		MeshFilter mf_toChange = Prefabs[prefabIndex].GetComponent<MeshFilter> ();
		mf.sharedMesh = mf_toChange.sharedMesh;
	}

}
