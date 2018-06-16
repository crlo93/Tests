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

  public void Piezas() {
    SceneManager.LoadScene("Inventario");
  }

  public void Jugar() {
    SceneManager.LoadScene("Pelea");
  }

  public void Login() {
    SceneManager.LoadScene("InicioSesion");
  }

  public void Registro() {
    SceneManager.LoadScene("Registro");
  }

  public void StartToLogin() {
    SceneManager.LoadScene("ScenesUI/InicioSesion");
  }

  public void StartToRegistro() {
    SceneManager.LoadScene("ScenesUI/Registro");
  }

  public void EditarPerfil() {
    SceneManager.LoadScene("EditarPerfil");
  }

  public void Mapa() {
    SceneManager.LoadScene("SceneMap/MapMaster");
  }

  public void Modificar() {
    SceneManager.LoadScene("EditarRobot");
  }

  public void completeFight() {
    SceneManager.LoadScene("SceneFight/Fight");
  }

  public void MostrarRobot() {
    SceneManager.LoadScene("MostrarRobot");
  }

  public void Robot() {
    SceneManager.LoadScene("ArmarRobot");
  }

}
