using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class EnemigoPartes : MonoBehaviour
{
    [SerializeField] private Enemigo parentEnemigo;
    [SerializeField] private float multiplicadorDanho;
    private Rigidbody rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void RecibirDanho(float danhoRecibido)
    {
        parentEnemigo.Vida -= danhoRecibido * multiplicadorDanho;
        if (parentEnemigo.Vida <= 0)
        {
            parentEnemigo.Morir();
        }
    }

    public void Explotar(float fuerzaExplosion, Vector3 puntoImpacto, float radioExplosion, float upModifier)
    {
        //Desactivar todo (animaciones, navmeshAgent, huesos: dynamic)
       parentEnemigo.Morir();
        rb.AddExplosionForce(fuerzaExplosion, puntoImpacto, radioExplosion, upModifier, ForceMode.Impulse);



    }
}
