using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoB : MonoBehaviour
{
    public GameObject acido;
    public Animator animator;
    

    // Start is called before the first frame update
    void Start()
    {
        acido.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") 
        {
            acido.SetActive(true);
            animator.SetTrigger("Atacar");
        }
    }

     void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            Debug.Log("Ha salido del trigger");
        }
    }
}
