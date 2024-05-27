using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC : MonoBehaviour
{
    public float velocity;
    private Vector3 frontmovement;
    private Vector3 sidemovement;   
    private Vector3 tmpgravity;
    private Rigidbody rb;
    public GameObject player;
    public float force;
    public float velocidadRot;
    public Transform Objeto;
    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 0;
        rb = GetComponent<Rigidbody>();    
    }

    // Update is called once per frame
    void Update()
    {

        frontmovement = Vector3.ProjectOnPlane(rb.transform.forward, Vector3.up)*Input.GetAxis("Vertical")*velocity*Time.deltaTime*-1;
        sidemovement = rb.transform.right * Input.GetAxis("Horizontal") * velocity/2 * Time.deltaTime*-1;
        tmpgravity = rb.velocity;
        rb.velocity = Vector3.zero;
        rb.velocity = frontmovement + sidemovement + (Vector3.up * tmpgravity.y);
        Objeto.Rotate(0, Input.GetAxis("Mouse X") * velocidadRot * Time.deltaTime, 0);

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
        rb.AddForce(Vector3.up*force, ForceMode.Impulse);
            
        }
        
    }
}
