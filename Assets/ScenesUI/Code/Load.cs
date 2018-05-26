using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class Load : MonoBehaviour {

 
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public float Tamanobarra(float min, float max) {
        return min / max;
    }

    public int Porcentaje(float min, float max, int fator) {
        return Mathf.RoundToInt(Tamanobarra (min, max) * fator);
    }
}
