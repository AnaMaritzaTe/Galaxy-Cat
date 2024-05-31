using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alertarEnemigo : MonoBehaviour
{
    public bool isDetected = false;
    public Animator alienAnim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isDetected = true;
            alienAnim.SetTrigger("Disparar");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isDetected = false;
            alienAnim.SetTrigger("Idle");

            Destroy(this.gameObject);
        }
    }
}
