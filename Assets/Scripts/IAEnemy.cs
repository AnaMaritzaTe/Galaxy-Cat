using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IAEnemy : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent agent;
    public float minStoppingDistance = 0.0f;  
    public float maxStoppingDistance = 3.0f;  
    public float changeInterval = 2f;  

    private float nextDistanceChangeTime = 0f;

    public VidaRata rata;
    public ControlVida vida;

    public float cantDano = 2f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // Actualizar la distancia de parada a intervalos regulares
        if (Time.time >= nextDistanceChangeTime)
        {
            agent.stoppingDistance = Random.Range(minStoppingDistance, maxStoppingDistance);
            nextDistanceChangeTime = Time.time + changeInterval;
        }

        // Actualizar la posición de destino del agente
        agent.destination = player.position;

        if (rata.isdead ) 
        {
           agent.isStopped = true;
        }

        if(agent.stoppingDistance==0.2f)
        {
            vida.hacerDano(cantDano);
        }
    }

}
