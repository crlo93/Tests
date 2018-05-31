using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dETA : MonoBehaviour {

    public Text Nombre;
    public Image Imagen;
    public Text nivel;
    
    // Use this for initialization
    void Start () {
		
	}

    public void Crea(Pieza Pi)
    {
        Nombre.text = Pi.Nombre;
        Imagen.sprite = Pi.Imagen;
        nivel.text =Pi.nivel;
        
    }


}
