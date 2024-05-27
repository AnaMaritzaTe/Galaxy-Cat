using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{
    private Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
