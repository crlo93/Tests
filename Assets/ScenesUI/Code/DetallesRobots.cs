using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetallesRobots : MonoBehaviour {

    public Text Nombre;
    public Image Imagen;
    public Text Descripcion;
    public Text Tipo;

    // Use this for initialization
    void Start () {
		
	}

    public void Crear(Robots robo) {
        Nombre.text = robo.Nombre;
        Imagen.sprite = robo.Imagen;
        Descripcion.text = robo.Descripcion;
        Tipo.text = robo.Tipo;

    }
}
