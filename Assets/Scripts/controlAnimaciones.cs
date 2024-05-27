using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlAnimaciones : MonoBehaviour
{
    public Animator playerAnimator;
    public bool isJumping = false;
    public float dano = 10f;
    public ControlVida contVida;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Animator 
        playerAnimator.SetFloat("Speed", Input.GetAxis("Vertical"));

        AnimatorClipInfo[] currentClipInfo = playerAnimator.GetCurrentAnimatorClipInfo(0);
        if (currentClipInfo.Length > 0)
        {
            AnimationClip currentClip = currentClipInfo[0].clip;

            Debug.Log("Clip de animación actual: " + currentClip.name);
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            playerAnimator.SetTrigger("Saltar");
            isJumping = true;
        }

        if (Input.GetMouseButton(1))
            playerAnimator.SetTrigger("Down");


        if (Input.GetMouseButtonDown(0))
        {
            playerAnimator.SetTrigger("Hit");
        }
        ///////Provisional PAra recibir daño
        if (Input.GetKeyDown(KeyCode.F))
        {
            playerAnimator.SetTrigger("Dano");

        }
        ///////Provisional PAra morir
        if (Input.GetKeyDown(KeyCode.Q))
        {
            playerAnimator.SetTrigger("Dead");
        }
        ///////Provisional PAra caer
        if (Input.GetKeyDown(KeyCode.R))
        {
            playerAnimator.SetTrigger("Caer");
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            playerAnimator.SetTrigger("Especial");
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("prensa"))
        {
            playerAnimator.SetTrigger("Dead");
        }
        
        if (other.gameObject.CompareTag("laser"))
        {
            playerAnimator.SetTrigger("Dano");
            dano += dano;
            contVida.hacerDano(dano);
            Debug.Log("El valor de daño es" + dano);
        }
        if (other.gameObject.CompareTag("coladera"))
        {
            playerAnimator.SetTrigger("Caer");
        }
    }
    
}
