using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Boomlagoon.JSON;
using UnityEngine;
using UnityEngine.UI;

public class PerfilObtener : MonoBehaviour
{

  public Text setNickname;
  public Text setEmail;
  private string url;

  // Use this for initialization
  void Start() {
    int id = PlayerPrefs.GetInt("id", 0);
    url = "http://robo-fightworld.bigbang.uno/api/Perfil.php";
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
        string nick = "";
        string email = "";
        foreach (JSONValue item in json["DATA"].Array)
        {
          JSONObject data = item.Obj;
          nick = data["usr_nick"].Str;
          email = data["usr_email"].Str;
        }
        setNickname.text = nick;
        setEmail.text = email;


      }
    }
    else
    {
      Debug.Log("getJSON ERROR");
      Debug.Log(www.error);
    }
    Debug.Log("getDataEnumerator END");
  }

}
