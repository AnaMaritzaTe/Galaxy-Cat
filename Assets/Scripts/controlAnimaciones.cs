using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlAnimaciones : MonoBehaviour
{
    public Animator playerAnimator;
    public bool hasJumped = false;
    public bool orueba = false;
    public float dano = 10f;
    public float vidaEx = 20f;
    public float force;
    public ControlVida contVida;
    private Rigidbody rb;
    public BoxCollider punoBoxCol;
    //public BoxCollider punoBoxCol;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
         desactivarColliderPuno();
    }

    // Update is called once per frame
    void Update()
    {
        //Animator 
        playerAnimator.SetFloat("Speed", Input.GetAxis("Vertical"));

        /*AnimatorClipInfo[] currentClipInfo = playerAnimator.GetCurrentAnimatorClipInfo(0);
        if (currentClipInfo.Length > 0)
        {
            AnimationClip currentClip = currentClipInfo[0].clip;

            Debug.Log("Clip de animación actual: " + currentClip.name);
        }*/
        Debug.Log("el valor de hasJumo es: " + hasJumped);

        if (Input.GetKeyDown(KeyCode.Space) && !hasJumped)
        {
            hasJumped = true;
            playerAnimator.SetTrigger("Saltar");
            rb.AddForce(Vector3.up * force, ForceMode.Impulse);
        }


        if (Input.GetMouseButton(1))
            playerAnimator.SetTrigger("Down");


        if (Input.GetMouseButtonDown(0))
        {
            
            activarColliderPuno();
            playerAnimator.SetTrigger("Hit");
        }
        if (Input.GetMouseButtonUp(0))
        {
            desactivarColliderPuno();

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
    /////////////////////////////////////////////////////
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
        }
        if (other.gameObject.CompareTag("coladera"))
        {
            playerAnimator.SetTrigger("Caer");
        }

        if (other.gameObject.CompareTag("corazon"))
        {
            contVida.masVida(vidaEx);
            Destroy(other.gameObject);
        }
    }

    public void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            hasJumped = false;
        }
    }

    public void activarColliderPuno()
    {
        punoBoxCol.enabled = true;
    }
    public void desactivarColliderPuno()
    {
        punoBoxCol.enabled = false;
    }

}

   
