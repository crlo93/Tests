using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Boomlagoon.JSON;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System;

public class PruebaArmar : MonoBehaviour
{

    // public Dropdown dropLegs;   
    private string urlSeleccionado;
    private string piezaSeleccionado;
    private string url;
    public Text Id;

    public Image SelectionImage;
    List<string> PiezasPiernas = new List<string>();
    List<string> ImagenWeb = new List<string>();
    List<Sprite> ItemList = new List<Sprite>();
    List<string> Reemplazo = new List<string>();
    List<string> Ids = new List<string>();
    private int itemSpot = 0;
   


    void Start()
    {
        url = "http://robo-fightworld.bigbang.uno/api/ObtenerPiezas/PartLegs.php";
        getData();

    }


    private void getData()
    {

        WWW www = new WWW(url);
        StartCoroutine("getDataEnumerator", www);
        //Im(ImagenWeb);
        print("holaentreagetdata");
       
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
                    PiezasPiernas.Add(data["prt_name"].Str);
                    ImagenWeb.Add(data["img"].Str);
                    Ids.Add(data["id_partMap"].Str);
                    //print(data["img"].Str);
                    
                }

                //Im(ImagenWeb);

            }
        }
        else
        {
            Debug.Log("getJSON ERROR");
            Debug.Log(www.error);
        }
        Debug.Log("getDataEnumerator END");
        print("Hola");

        foreach(string i in ImagenWeb)
        {
            Reemplazo.Add(i.Replace('*','/').ToString());
           
        }

   
     
        foreach (string i in Reemplazo)
        {
            
         print(i);
            WWW ww = new WWW(i);
            yield return ww;
            Texture2D img = new Texture2D(1, 1);
            ww.LoadImageIntoTexture(img);
            ItemList.Add(Sprite.Create(img, new Rect(0, 0, img.width, img.height), Vector2.one / 2));
           // ItemList.Add(Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0, 0)));
            print("si entro");

        }
        SelectionImage.sprite = ItemList[0];
        
    }

    IEnumerator Im(List<string> Prueba)
    {
        print("Hola");
     
        foreach (string i in Prueba)
        {
            WWW www = new WWW(i);
            yield return www;
            Texture2D img = new Texture2D(1, 1);
            www.LoadImageIntoTexture(img);
            ItemList.Add(Sprite.Create(img, new Rect(0, 0, img.width, img.height), Vector2.one / 2));
           // ItemList.Add(Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0, 0)));
            print("si entro");
        
        }


        

            //img.sprite = 

        /* WWW imag = new WWW(urlink);
         yield return imag;

         Texture2D img = new Texture2D(1, 1);
         imag.LoadImageIntoTexture(img);
         Sprite sprite = Sprite.Create(img, new Rect(0, 0, img.width, img.height), Vector2.one / 2);
         GetComponent<SpriteRenderer>().sprite = sprite;
         */
        }



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

    /*public void Lista()
    {
        dropLegs.AddOptions(PiezasPiernas);
    }
    
    
    public void DropDown_Index(int index)
    {
        piezaSeleccionado = PiezasPiernas[index];
        urlSeleccionado = ImagenWeb[index];
        print(piezaSeleccionado);
        //CargarImg(urlSeleccionado);
    }

    public void onHerkunftChoose()
    {

        int chosenInt = GameObject.Find("DropdownL").GetComponent<Dropdown>().value;
        print(chosenInt);
    }
    */
}
