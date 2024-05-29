using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlVida : MonoBehaviour
{
    public float vida;
    public float maximoVida;
    public BarraVida barraVida;
    // Start is called before the first frame update
    void Start()
    {
        vida = maximoVida;
        barraVida.InicializarBarraVida(vida);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void hacerDano(float dano)
    {
        vida -= dano;
        barraVida.CambiarVidaActual(vida);
        if (vida <= 0) 
        {
            Debug.Log("Esta muerto el michi");
        }
    }

    public void masVida(float CantidadVida)
    {
        vida += CantidadVida;
        barraVida.CambiarVidaActual(vida);
        if(vida >=100)
        {
            vida = 100;
        }
    }
}
