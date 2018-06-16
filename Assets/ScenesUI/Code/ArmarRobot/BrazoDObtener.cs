using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Boomlagoon.JSON;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System;

public class BrazoDObtener : MonoBehaviour
{
  private string url;

  //Componentes de interfaz
  public Text Id;
  public Image SelectionImage;

  //Listas que guardan datos de JSON
  List<string> PiezasBrazoD = new List<string>();
  List<string> ImagenWeb = new List<string>();
  List<string> Reemplazo = new List<string>();


  //Lista de Sprites
  List<Sprite> ItemList = new List<Sprite>();
  List<string> Ids = new List<string>();
  private int itemSpot = 0;



  void Start()
  {
    url = "http://robo-fightworld.bigbang.uno/api/ObtenerPiezas/PartArmR.php";
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

        foreach (JSONValue item in json["DATA"].Array)
        {
          JSONObject data = item.Obj;
          PiezasBrazoD.Add(data["prt_name"].Str);
          ImagenWeb.Add(data["img"].Str);
          Ids.Add(data["id_partMap"].Str);


        }


      }
    }
    else
    {
      Debug.Log("getJSON ERROR");
      Debug.Log(www.error);
    }
    Debug.Log("getDataEnumerator END");


    //Remplazar signos de la URL
    foreach (string i in ImagenWeb)
    {
      Reemplazo.Add(i.Replace('*', '/').ToString());

    }

    //Hace la lista de sprites con los url
    foreach (string i in Reemplazo)
    {

      print(i);
      WWW ww = new WWW(i);
      yield return ww;
      Texture2D img = new Texture2D(1, 1);
      ww.LoadImageIntoTexture(img);
      ItemList.Add(Sprite.Create(img, new Rect(0, 0, img.width, img.height), Vector2.one / 2));


    }
    SelectionImage.sprite = ItemList[0];
    Id.text = Ids[0];

  }



  //Botones de flecha para cambiar imagen
  public void Right()
  {
    if (itemSpot < ItemList.Count - 1)
    {
      itemSpot++;
      SelectionImage.sprite = ItemList[itemSpot];
      print(ItemList[itemSpot]);
      Id.text = Ids[itemSpot];
    }
  }

  public void Left()
  {
    if (itemSpot > 0)
    {
      itemSpot--;
      SelectionImage.sprite = ItemList[itemSpot];
      print(ItemList[itemSpot]);
      Id.text = Ids[itemSpot];
    }
  }



}
