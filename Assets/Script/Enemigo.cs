using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class Enemigo : MonoBehaviour
{
    private NavMeshAgent agent;
    private Personaje_3a personaje;
    private Animator animator;
    private bool ventanaAbierta;
    private bool puedoDanhar = true;
    [SerializeField] private Transform puntoAtaque1;
    [SerializeField] private Transform puntoAtaque2;
    [SerializeField] private float radioDeAtaque;
    [SerializeField] private LayerMask queEsdañable;
    [SerializeField] private float danhoEjercido;


 

    void Start()
    {
       agent = GetComponent<NavMeshAgent>();
       personaje = GameObject.FindObjectOfType<Personaje_3a>();
        animator = GetComponent<Animator>();
    }

  
    void Update()
    {
        Perseguir();
        if(ventanaAbierta && puedoDanhar)
        {
            DetectarImpacto();
        } 
    }

    private void DetectarImpacto()
    {
       Collider[] zonasDetectadas1 = Physics.OverlapSphere(puntoAtaque1.position, radioDeAtaque, queEsdañable);
       Collider[] zonasDetectadas2 = Physics.OverlapSphere(puntoAtaque2.position, radioDeAtaque, queEsdañable);
        if(zonasDetectadas1.Length > 0)
        {
            for (int i = 0; i < zonasDetectadas1.Length; i++)
            {
                zonasDetectadas1[i].GetComponent<Personaje_3a>().RecibirDanho(danhoEjercido);

            }
            puedoDanhar = false;
        }
        if(zonasDetectadas2.Length > 0)
        {

        }

    }

    private void Perseguir()
    {
        agent.SetDestination(personaje.transform.position);

        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            agent.isStopped = true;
            animator.SetBool("Ataque", true);
        }
    }

    private void FinAtaque()
    {
        agent.isStopped = false;
        animator.SetBool("Ataque", false);
        puedoDanhar = true;
    } 
    private void AbrirVentanaAtaque()
    {
       ventanaAbierta = true;
    }  
    private void CerrarVentanaAtaque()
    {
       ventanaAbierta = false;
    }
}
