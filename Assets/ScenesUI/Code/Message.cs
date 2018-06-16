using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;
using UnityEngine.UI;
using Boomlagoon.JSON;

public class Message : MonoBehaviour {

  public Message () {

  }

  private bool showPopUp = false;
  private String mssg = "";

  public void alert(String mssg) {
    this.mssg = mssg;
    showPopUp = true;
  }

  public void OnGUI() {
    if (showPopUp) {
      GUI.Window(0, new Rect((Screen.width / 2) - 150, (Screen.height / 2) - 75, 300, 150), ShowGUI, "ERROR");
    }
  }

  public void ShowGUI(int windowID) {
    // You may put a label to show a message to the player

    GUI.Label(new Rect(65, 40, 200, 30), this.mssg);

    // You may put a button to close the pop up too

    if (GUI.Button(new Rect(50, 80, 75, 30), "OK")) {
      showPopUp = false;
      // you may put other code to run according to your game too
    }

  }

}
