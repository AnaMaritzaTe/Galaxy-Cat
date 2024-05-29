using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class sistemaRecoleccion : MonoBehaviour
{
    public bool hasMapa = false;
    public int numPescaditos;
    public TextMeshProUGUI numPezText;

    private void Update()
    {
        numPezText.text = numPescaditos.ToString();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pez"))
        {
            Destroy(other.gameObject);
            numPescaditos++;    
        }

        if (other.gameObject.CompareTag("mapa"))
        {
            Destroy(other.gameObject);
            hasMapa = true;
        }
    }
}
