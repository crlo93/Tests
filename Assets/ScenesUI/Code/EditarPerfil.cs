using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;
using UnityEngine.UI;
using System;

public class EditarPerfil : MonoBehaviour
{

    public GameObject Nickname;
    public GameObject LastPass;
    public GameObject NewPass;
    public GameObject AgainPass;
 

    private string Nick;
    private string Last;
    private string New;
    private string ANew;

    private string usuario = "1";


    public void Regresar()
    {
        SceneManager.LoadScene("MiPerfil");
    }

    public void Actualizar()
    {
        if (Nick != "")
        {
        }
        else
        {
            Debug.LogWarning("Campo obligatorio");
        }


        if (Last != "")
        {
        }
        else
        {
            Debug.LogWarning("Campo obligatorio");
        }

        if (New != "")
        {
        }
        else
        {
            Debug.LogWarning("Campo obligatorio");
        }
        if (ANew != "")
        {
        }
        else
        {
            Debug.LogWarning("Campo obligatorio");
        }


        string url = "http://robo-fightworld.bigbang.uno/api/EditarPerfil.php";

        WWWForm formDate = new WWWForm();
        formDate.AddField("table", "user");
        formDate.AddField("usr_nick", Nick);
        formDate.AddField("usr_password", New);
        formDate.AddField("usr_id", usuario);

        WWW www = new WWW(url, formDate);
        StartCoroutine(request(www));

    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (Nick != "" && Last != "" && New != "" && ANew != "" )
            {
             
                    Actualizar();
                }
             
            }
        


    
     Nick=Nickname.GetComponent<InputField>().text;
     Last=LastPass.GetComponent<InputField>().text; ;
     New=NewPass.GetComponent<InputField>().text; 
     ANew=AgainPass.GetComponent<InputField>().text; ;
   

    }
    IEnumerator request(WWW www)
    {

        yield return www;
        //displayText.text = www.text;
        //saveText.text = www.text;
        Regresar();
    }

}

