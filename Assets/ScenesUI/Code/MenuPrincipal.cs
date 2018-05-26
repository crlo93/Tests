using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour {

    public void IrPerfil() {
        SceneManager.LoadScene("MiPerfil");
    }

    public void Armar() {
        SceneManager.LoadScene("Armar");

    }

    public void Piezas()
    {
        SceneManager.LoadScene("Inventario");

    }

    public void Jugar() {
        SceneManager.LoadScene("Pelea");
    }

	public void Login() {

		SceneManager.LoadScene("InicioSesion");
	}
	public void Registro(){
		SceneManager.LoadScene("Registro");


	}
	public void EditarPerfil() {
		SceneManager.LoadScene("EditarPerfil");
	}

	public void Mapa() {
		SceneManager.LoadScene("PantallaP");
	}

}
