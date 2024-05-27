using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pararPren : MonoBehaviour
{
    public bool isCross = false;
    public aminPrensa animP;
    public GameObject Prensa;
    public bool ObtenerValorPrivado()
    {
        return isCross;
    }
    // Start is called before the first frame update
    void Start()
    {
        
        //animP = GetComponent<aminPrensa>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isCross)
        {
            Destroy(Prensa);
            Destroy(this);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animP.funcionParar();
            isCross = true;
        }

    }
}
