using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    private NavMeshAgent agent;
    private Personaje_3a personaje;
    void Start()
    {
       agent = GetComponent<NavMeshAgent>();
       personaje = GameObject.FindObjectOfType<Personaje_3a>();
    }

  
    void Update()
    {
        agent.SetDestination(personaje.transform.position);
    }
}
