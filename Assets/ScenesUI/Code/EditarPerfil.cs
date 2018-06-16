using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;
using UnityEngine.UI;
using System;
using Boomlagoon.JSON;
using UnityEngine.Networking;

public class EditarPerfil : MonoBehaviour {

  public GameObject Nickname;
  public GameObject LastPass;
  public GameObject NewPass;
  public GameObject AgainPass;

  private string Nick;
  private string Last;
  private string New;
  private string ANew;

  public string password="";
  private string url;

  private bool showPopUp = false;

  public void Regresar() {
    SceneManager.LoadScene("MiPerfil");
  }

  public void Actualizar()
  {
    Nick = Nickname.GetComponent<InputField>().text;
    Last = LastPass.GetComponent<InputField>().text;
    New = NewPass.GetComponent<InputField>().text;
    ANew = AgainPass.GetComponent<InputField>().text;

    if (New.Length < 8) {
      showPopUp = true;
    } else {
      if (String.Equals(Last, password) && Nick != "" && Last != "" && New != "" && ANew != "" && String.Equals(New, ANew)) {

        Debug.LogWarning(" SI COINCIDEN ");
        string url = "http://robo-fightworld.bigbang.uno/api/EditarPerfil.php";

        WWWForm formDate = new WWWForm();
        formDate.AddField("table", "user");
        formDate.AddField("usr_nick", Nick);
        formDate.AddField("usr_password", New);
        int id = PlayerPrefs.GetInt("id", 0);
        formDate.AddField("usr_id", id);

        WWW www = new WWW(url, formDate);
        StartCoroutine(request(www));
      } else {
        Debug.LogWarning("NO COINCIDEN ");
        showPopUp = true;
      }

    }


  }
  // Use this for initialization
  void Start() {
    url = "http://robo-fightworld.bigbang.uno/api/ObtenerContra.php";
    getData();
  }

  // Update is called once per frame
  void Update()
  {

    Nick = Nickname.GetComponent<InputField>().text;
    Last = LastPass.GetComponent<InputField>().text;
    New = NewPass.GetComponent<InputField>().text;
    ANew = AgainPass.GetComponent<InputField>().text;



  }
  IEnumerator request(WWW www)
  {

    yield return www;
    Regresar();
  }




  private void getData()
  {
    int id = PlayerPrefs.GetInt("id", 0);
    WWWForm iForm = new WWWForm();
    iForm.AddField("id", id);
    WWW www = new WWW(url, iForm);
    StartCoroutine("getDataEnumerator", www);
  }

  private IEnumerator getDataEnumerator(WWW www)
  {
    Debug.Log("getDataEnumerator START");
    yield return www;
    if (www.error == null)
    {
      string serviceData = www.text;
      JSONObject json = JSONObject.Parse(serviceData);
      if (json == null)
      {
        Debug.Log("getJSON NULL");
        Debug.Log("No data converted");
      }
      else
      {

        foreach (JSONValue item in json["DATA"].Array)
        {
          JSONObject data = item.Obj;

          password = data["usr_password"].Str;
        }
        print(password);
      }
    }
    else
    {
      Debug.Log("getJSON ERROR");
      Debug.Log(www.error);
    }
    Debug.Log("getDataEnumerator END");
  }

  public void OnGUI()
  {
    if (showPopUp)
    {
      GUI.Window(0, new Rect((Screen.width / 2) - 150, (Screen.height / 2) - 75
      , 300, 150), ShowGUI, "ERROR");

    }
  }

  public void ShowGUI(int windowID)
  {
    // You may put a label to show a message to the player

    GUI.Label(new Rect(65, 40, 200, 30), "REVISA LOS CAMPOS");

    // You may put a button to close the pop up too

    if (GUI.Button(new Rect(50, 80, 75, 30), "OK"))
    {
      showPopUp = false;
      // you may put other code to run according to your game too
    }

  }
}
