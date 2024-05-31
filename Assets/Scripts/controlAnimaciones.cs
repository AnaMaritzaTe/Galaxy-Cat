using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controlAnimaciones : MonoBehaviour
{
    public Animator playerAnimator;
    public bool hasJumped = false;
    public bool orueba = false;
    public float dano = 5f;
    public float vidaEx = 20f;
    public float force;
    public ControlVida contVida;
    private Rigidbody rb;
    public BoxCollider rbCollider;
    public BoxCollider punoBoxCol;
    public bool isDead = false;
    public sistemaRecoleccion num;
    //public BoxCollider punoBoxCol;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //rbCollider = GetComponent<BoxCollider>();
        
         desactivarColliderPuno();
        desactivarColliderEspecial();
    }

    // Update is called once per frame
    void Update()
    {
        //Animator 
        playerAnimator.SetFloat("Speed", Input.GetAxis("Vertical"));


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

        if (num.numPescaditos >= 20)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                activarColliderEspecial();
                playerAnimator.SetTrigger("Especial");
            }
            if(Input.GetKeyUp(KeyCode.E))
            {
                desactivarColliderEspecial();
            }
        }
    }
    /////////////////////////////////////////////////////
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("prensa"))
        {
            playerAnimator.SetTrigger("Dead");
            isDead = true;
            
        }

        if (other.gameObject.CompareTag("laser"))
        {
            playerAnimator.SetTrigger("Dano");
            //dano += dano;
            contVida.hacerDano(dano);
        }
        if (other.gameObject.CompareTag("coladera"))
        {
            playerAnimator.SetTrigger("Caer");
            isDead = true;
        }

        if (other.gameObject.CompareTag("corazon"))
        {
            contVida.masVida(vidaEx);
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Finish"))
        {
            Debug.Log("colisiona");
            SceneManager.LoadScene("final");
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

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Bullet"))
        {
            playerAnimator.SetTrigger("Dano");
            //dano += dano;
            contVida.hacerDano(dano);
        }

        if (collision.gameObject.CompareTag("Finish"))
        {
            Debug.Log("colisiona");
            SceneManager.LoadScene("final");
        }
    }

    public void activarColliderEspecial()
    {
        rbCollider.enabled = true;
    }
    public void desactivarColliderEspecial()
    {
        rbCollider.enabled = false;
    }
}

   
