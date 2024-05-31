using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class activeRata : MonoBehaviour
{
    public GameObject Rata;
    void Start()
    {
        Rata.SetActive(false);
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        { Rata.SetActive(true); }
    }
}
