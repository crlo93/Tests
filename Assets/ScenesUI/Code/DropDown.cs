using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDown : MonoBehaviour {
    List<string> nombres = new List<string>() { "Pau", "Omar", "Noe","Diego" };
	public Dropdown DropHead, DropBody, DropArmR, DropArmL, DropLegs;
    public Text seleccionado;
     
    public void DropDown_Index(int index) {
        
        seleccionado.text = nombres[index];
        string sele = nombres[index];
        print(sele);
    }
    void Start()
    {
       
    }

    void Lista() {
        
       DropHead.AddOptions(nombres);
        DropBody.AddOptions(nombres);
        DropArmR.AddOptions(nombres);
        DropArmL.AddOptions(nombres);
        DropLegs.AddOptions(nombres);
    }

}
