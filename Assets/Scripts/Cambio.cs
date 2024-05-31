using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cambio : MonoBehaviour
{
    public GameObject positionGato;
    public GameObject gato;
    public CinemachineVirtualCamera camaraFrontal;
    public bool isChange = false;

    // Start is called before the first frame update
    void Start()
    {
        camaraFrontal.gameObject.SetActive(false);
        camaraFrontal.m_Priority = 9;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            gato.transform.position = positionGato.transform.position;
            gato.transform.rotation = positionGato.transform.rotation;
            camaraFrontal.gameObject.SetActive(true);
            camaraFrontal.m_Priority = 11;
            isChange = true;
        }
    }
}
