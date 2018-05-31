using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pieza
{
    public string Nombre;
    public Sprite Imagen;
    public string nivel;
    


}

public class ArmarRobot : MonoBehaviour {


    public Sprite P1;
    public Sprite P2;
    public Sprite P3;

    public GameObject PrefabRobo;
    public Transform Contene;

    // Use this for initialization
    void Start () {
        List<Pieza> pz = new List<Pieza>
        {
            new Pieza{Nombre="CabezaO", Imagen= P1, nivel="20"},
            new Pieza{Nombre="CabezaB", Imagen= P2, nivel="30"},
            new Pieza{Nombre="Brazo", Imagen= P3, nivel="30"}
        };

        for (int i = 0; i < 3; i++)
        {
            foreach (var item in pz)
            {
                GameObject _R = Instantiate(PrefabRobo, Contene);
                _R.GetComponent<dETA>().Crea(item);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
