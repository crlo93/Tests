using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Boomlagoon.JSON;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System;

public class MostrarRobots: MonoBehaviour
{
  private string url;

  //Componentes de interfaz

  public Image Head;
  public Image Body;
  public Image ArmR;
  public Image ArmL;
  public Image Legs;

  public Sprite OH;
  public Sprite OB;
  public Sprite OAR;
  public Sprite OAL;
  public Sprite OL;

  public Sprite BH;
  public Sprite BB;
  public Sprite BAR;
  public Sprite BAL;
  public Sprite BL;

  //URL DE IMAGENES DE OCELYNDE
  private string OLegs = "http://robo-fightworld.bigbang.uno/api/ModelsImages/OcelyndeLegs.png";
  private string OHead = "http://robo-fightworld.bigbang.uno/api/ModelsImages/OcelyndeHead.png";
  private string OArmL = "http://robo-fightworld.bigbang.uno/api/ModelsImages/OcelyndeArmLeft.png";
  private string OArmR = "http://robo-fightworld.bigbang.uno/api/ModelsImages/OcelyndeArmRight.png";
  private string OBody= "http://robo-fightworld.bigbang.uno/api/ModelsImages/OcelyndeBody.png";

  //URL DE IMAGENES DE BULL
  private string BLegs = "http://robo-fightworld.bigbang.uno/api/ModelsImages/GroundBullLegs.png";
  private string BHead = "http://robo-fightworld.bigbang.uno/api/ModelsImages/GroundBullHead.png";
  private string BArmL = "http://robo-fightworld.bigbang.uno/api/ModelsImages/GroundBullArmLeft.png";
  private string BArmR = "http://robo-fightworld.bigbang.uno/api/ModelsImages/GroundBullArmRight.png";
  private string BBody = "http://robo-fightworld.bigbang.uno/api/ModelsImages/GroundBullBody.png";


  //Listas que guardan datos de JSON
  List <string> Piezas = new List<string>();
  // List<string> ImagenWeb = new List<string>();
  List<Sprite> Reemplazo = new List<Sprite>();


  //Lista de Sprites
  List<Sprite> ItemList = new List<Sprite>();
  List<string> Ids = new List<string>();
  private int itemSpot = 0;



  void Start()
  {
    url = "http://robo-fightworld.bigbang.uno/api/ObtenerRobot.php";
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
          if (data["id_legs"].Str == "1") {
            //Piezas.Add(OLegs);
            Legs.sprite = OL;
          }
          else {
            if (data["id_legs"].Str == "10") {
              //Piezas.Add(BLegs);
              Legs.sprite = BL;
            }
          }
          if (data["id_body"].Str == "5")
          {
            //Piezas.Add(OBody);
            Body.sprite = OB;
          }
          else {
            if(data["id_body"].Str=="7"){
              // Piezas.Add(BBody);
              Body.sprite = BB;
            }
          }

          if (data["id_arml"].Str == "3")
          {
            //Piezas.Add(OArmL);
            ArmL.sprite = OAL;
          }
          else {
            if (data["id_arml"].Str == "8")
            {
              // Piezas.Add(BArmL);
              ArmL.sprite = BAL;
            }
          }

          if (data["id_armr"].Str == "4")
          {
            //Piezas.Add(OArmR);
            ArmR.sprite = OAR;
          }
          else {
            if(data["id_armr"].Str == "9")
            {
              ArmR.sprite = BAR;
            }
          }

          if (data["id_head"].Str == "2") {

            Head.sprite = OH;
          }
          else
          {
            if (data["id_head"].Str == "6")
            {
              //Piezas.Add(BHead);
              Head.sprite = BH;
            }
          }

        }


      }
    }
    else
    {
      Debug.Log("getJSON ERROR");
      Debug.Log(www.error);
    }
    Debug.Log("getDataEnumerator END");



    /*
    foreach (string i in Piezas)
    {

    //print(i);
    WWW ww = new WWW(i);
    yield return ww;
    Texture2D img = new Texture2D(1, 1);
    ww.LoadImageIntoTexture(img);
    ItemList.Add(Sprite.Create(img, new Rect(0, 0, img.width, img.height), Vector2.one / 2));


  }

  Legs.sprite = ItemList[0];
  Body.sprite = ItemList[1];
  ArmL.sprite = ItemList[2];
  ArmR.sprite = ItemList[3];
  Head.sprite = ItemList[4];
  //Head.sprite = Reemplazo[0];
  */
}





}
