using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class vidaEnemigo : MonoBehaviour
{
    public int hp;
    public int danoGolpe;
    public Animator animEnemi;
    public bool isdead = false;

    


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
        if(other.gameObject.tag == "golpe")
        {
            if(animEnemi != null)
            {
                animEnemi.Play("GetHit");
            }
            hp -= danoGolpe;
        }
        if(hp <= 0)
        {
            animEnemi.Play("Die");
            isdead = true;
        }
        
    }

    


}
