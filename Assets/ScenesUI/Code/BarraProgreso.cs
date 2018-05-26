using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraProgreso : MonoBehaviour {

    public Load _barradeProgreso;
    public GameObject _barra;
    public Text _texto;
    public float _max;
    public float _ProgresoActual;


	// Use this for initialization
	void Start () {
        _barradeProgreso = this.gameObject.GetComponent<Load>();

	}
	
	// Update is called once per frame
	void Update () {
        _barra.transform.localScale = new Vector3(_barradeProgreso.Tamanobarra(_ProgresoActual, _max), _barradeProgreso.transform.localScale.y, _barradeProgreso.transform.localScale.z);
        _texto.text = _barradeProgreso.Porcentaje(_ProgresoActual, _max, 100) + "%";
        if (_ProgresoActual < _max)
        {
            _ProgresoActual += Time.deltaTime * 18;

        }
        else {
            _texto.text = "100%";
        }

    }



}
