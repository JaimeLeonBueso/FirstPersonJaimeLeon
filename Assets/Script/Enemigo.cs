using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class Enemigo : MonoBehaviour
{

    [Header("Sistema combate")]
    [SerializeField] private float vida;
    [SerializeField] private float danhoEnemigo;
    [SerializeField] private Transform puntoAtaque1;
    [SerializeField] private Transform puntoAtaque2;
    [SerializeField] private float radioAtaque;
    [SerializeField] private LayerMask queEsDanhable;

    private NavMeshAgent agent;
    private Personaje personaje;
    private Animator animator;
    private bool ventanaAbierta;
    private bool puedoDanhar = true;
    Rigidbody[] huesos;

    public float Vida { get => vida; set => vida = value; }



    void Start()
    {
       agent = GetComponent<NavMeshAgent>();
       personaje = GameObject.FindObjectOfType<Personaje>();
       animator = GetComponent<Animator>();
       huesos = GetComponentsInChildren<Rigidbody>();
       CambiarEstadoHuesos(true);
    }


    void Update()
    {
        if (agent.enabled)
        {
            Perseguir();
            if (ventanaAbierta && puedoDanhar)
            {
                DetectarImpacto();
            }
        } 
    }

    private void DetectarImpacto()
    {
       Collider[] zonasDetectadas1 = Physics.OverlapSphere(puntoAtaque1.position, radioAtaque, queEsDanhable);
       Collider[] zonasDetectadas2 = Physics.OverlapSphere(puntoAtaque2.position, radioAtaque, queEsDanhable);
        if(zonasDetectadas1.Length > 0)
        {
            for (int i = 0; i < zonasDetectadas1.Length; i++)
            {
                zonasDetectadas1[i].GetComponent<Personaje>().RecibirDanho(danhoEnemigo);

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

        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
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
    public void Morir()
    {
        CambiarEstadoHuesos(false);
        animator.enabled = false;
        agent.enabled = false;
        Destroy(gameObject, 10);
    }


    private void CambiarEstadoHuesos(bool estado)
    {
        for (int i = 0; i < huesos.Length; i++)
        {
            huesos[i].isKinematic = estado;
        }
    }

  
}
