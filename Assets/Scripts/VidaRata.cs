using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaRata : MonoBehaviour
{
    public int hp;
    public int danoEspecial;
    public Animator animRata;
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
        if (other.gameObject.tag == "especial")
        {
            if (animRata != null)
            {
                animRata.SetTrigger("hit");
            }
            hp -= danoEspecial;
        }
        if (hp <= 0)
        {
            animRata.SetTrigger("morir");
            isdead = true;
        }
    }
}
