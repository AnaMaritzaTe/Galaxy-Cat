using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class verJugador : MonoBehaviour
{

    public Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform != null)
        {
            
            Vector3 direction = playerTransform.position - transform.position;
            direction.y = 0; 

            
            if (direction != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
            }
        }
    }
}
