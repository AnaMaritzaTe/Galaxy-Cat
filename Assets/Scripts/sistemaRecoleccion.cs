using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class sistemaRecoleccion : MonoBehaviour
{
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
    }
}
