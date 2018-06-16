using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Boomlagoon.JSON;
using UnityEngine;
using UnityEngine.UI;

public class NombreRobot: MonoBehaviour
{

  public Text setRobot;

  private string url;

  // Use this for initialization
  void Start()
  {
    url = "http://robo-fightworld.bigbang.uno/api/ObtenerNombreRobot.php";
    getData();
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
        string robo= "";

        foreach (JSONValue item in json["DATA"].Array)
        {
          JSONObject data = item.Obj;
          robo = data["name"].Str;

        }
        setRobot.text = robo;



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
