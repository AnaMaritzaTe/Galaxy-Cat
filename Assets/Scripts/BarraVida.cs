using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{
    private Slider slider;
    public GameObject mapaObj;
    public sistemaRecoleccion mapa;
    

    // Start is called before the first frame update
    void Start()
    {
        mapaObj.SetActive(false);
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(mapa.hasMapa)
        {
            mapaObj.SetActive(true);
        }
    }
    public void CambiarVidaMAxima (float vidaMaxima)
    {
        slider.value = vidaMaxima;
    }

    public void CambiarVidaActual(float cantidadVida) 
    { 
        slider.value = cantidadVida;
    }

    public void InicializarBarraVida(float cantidadVida)
    {
        CambiarVidaMAxima(cantidadVida);
        CambiarVidaActual(cantidadVida);
    }
}
