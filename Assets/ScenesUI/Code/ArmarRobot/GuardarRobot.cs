using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;
using UnityEngine.UI;
using System;

public class GuardarRobot : MonoBehaviour {

    public GameObject TextHead;
    public GameObject TextArmR;
    public GameObject TextArmL;
    public GameObject TextBody;
    public GameObject TextLegs;
    public GameObject Nombre;

    private string THead;
    private string TArmR;
    private string TArmL;
    private string TBody;
    private string TLegs;
    private string Name;


    public void Regresar() {
        SceneManager.LoadScene("ArmarRobot");
    }

    public void RegistrarRobot()
    {
        Debug.Log("Inicio de registro");
        THead = TextHead.GetComponent<Text>().text;
        TArmR = TextArmR.GetComponent<Text>().text;
        TArmL = TextArmL.GetComponent<Text>().text;
        TBody = TextBody.GetComponent<Text>().text;
        TLegs = TextLegs.GetComponent<Text>().text;
        Name = Nombre.GetComponent<InputField>().text;

        if (Name != "")
        {
        string url = "http://robo-fightworld.bigbang.uno/api/GuardarRobot.php";
        int id = PlayerPrefs.GetInt("id", 0);

        WWWForm formDate = new WWWForm();
        formDate.AddField("table", "robot");
        formDate.AddField("id_usuario", id);
        formDate.AddField("id_arml", TArmL);
        formDate.AddField("id_armr", TArmR);
        formDate.AddField("id_head", THead);
        formDate.AddField("id_body", TBody);
        formDate.AddField("id_legs", TLegs);
        formDate.AddField("active", "true");
        formDate.AddField("name", Name);

        WWW www = new WWW(url, formDate);
        StartCoroutine(request(www));
        }
        else
        {
            Debug.LogWarning("Campo obligatorio");
        }



    }
    // Use this for initialization
    void Start () {

	}

    // Update is called once per frame
    void Update() {

        THead = TextHead.GetComponent<Text>().text;
        TArmR = TextArmR.GetComponent<Text>().text;
        TArmL = TextArmL.GetComponent<Text>().text;
        TBody = TextBody.GetComponent<Text>().text; ;
        TLegs = TextLegs.GetComponent<Text>().text;
        Name = Nombre.GetComponent<InputField>().text;

    }
        IEnumerator request(WWW www)
        {

            yield return www;
            //displayText.text = www.text;
            //saveText.text = www.text;
            Debug.Log(www.text);
            Regresar();
        }

    }
