using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EXAMPLE : MonoBehaviour
{


    // The output of the image
    public Image img;

    // The source image
    string url = "http://robo-fightworld.bigbang.uno/api/ModelsImages/OcelyndeLegs.png";

    IEnumerator Start()
    {
        WWW www = new WWW(url);
        yield return www;
        img.sprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0, 0));
    }
}
