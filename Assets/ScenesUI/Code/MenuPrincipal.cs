using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour {

    public void IrPerfil() {
        SceneManager.LoadScene("MiPerfil");
    }

    public void Armar() {
        SceneManager.LoadScene("ArmarRobot");

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

    public void ArmarHead() {
        SceneManager.LoadScene("ArmarHead");
    
    }

    public void ArmarBody()
    {
        SceneManager.LoadScene("ArmarBody");

    }

    public void ArmarArmL()
    {
        SceneManager.LoadScene("ArmarArmL");

    }

    public void ArmarArmR()
    {
        SceneManager.LoadScene("ArmarArmR");

    }

    public void ArmarLegs()
    {
        SceneManager.LoadScene("ArmarLegs");

    }
   
}
