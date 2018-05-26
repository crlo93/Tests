using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Robots
{
    public string Nombre;
    public Sprite Imagen;
    public string Descripcion;
    public string Tipo;
}

public class InvenPrueba : MonoBehaviour
{

    public Sprite R1;
    public Sprite R2;
    public Sprite R3;
    public GameObject PrefabR;
    public Transform Contenedor;
    // Use this for initialization
    void Start()
    {

        List<Robots> Robot = new List<Robots>
        {
           new Robots {Nombre="Pieza1", Descripcion="Fuerza=20 Ataque=30 Daño=40", Tipo= "Agua", Imagen= R1},
           new Robots {Nombre="Pieza2", Descripcion="Fuerza=50 Ataque=20 Daño=60", Tipo= "Tierra", Imagen= R2},
           new Robots {Nombre="Pieza3", Descripcion="Fuerza=60 Ataque=30 Daño=50", Tipo= "Aire", Imagen= R3},


        };
        for (int i = 0; i < 3; i++)
        {
            foreach (var item in Robot)
            {
                GameObject _Robo = Instantiate(PrefabR, Contenedor);
                _Robo.GetComponent<DetallesRobots>().Crear(item);
            }
        }


    }
}