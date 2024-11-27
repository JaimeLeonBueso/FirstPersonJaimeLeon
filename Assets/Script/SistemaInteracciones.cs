using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaInteracciones : MonoBehaviour
{
    [SerializeField] private float distanciaInteraccion;



    private Camera cam;
    private Transform interactuableActual;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        DeteccionInteractuable();
    }

    private void DeteccionInteractuable()
    {
        //Si conseguimos ver algo (lo que sea)
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hit, distanciaInteraccion))
        {
            //Mira a ver si lleva el script de tipo "CajaMunicion"
            if (hit.transform.TryGetComponent(out WeaponCrate script))
            {
                //Si lo lleva, este es tu interactuable
                interactuableActual = script.transform;

                //Y a este interactuable, le enciendes el outline.
                interactuableActual.GetComponent<Outline>().enabled = true;


                if(Input.GetKeyDown(KeyCode.E))
                {
                    script.AbrirCaja();

                }
            }
        }
        //Si no ves nada, y tenías un interactuable de otra ocasión anterior
        else if (interactuableActual != null)
        {
            //Entonces, le tienes que quitar el outline
            interactuableActual.GetComponent<Outline>().enabled = false;

            //Ya no tienes interactuable.
            interactuableActual = null;
        }
    }
}
