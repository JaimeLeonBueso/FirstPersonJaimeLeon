using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class EnemigoPartes : MonoBehaviour
{
    [SerializeField] private Enemigo parentEnemigo;
    [SerializeField] private Enemigo multiplicadorDanho;
   public void RecibirDanho(float danhoRecibido)
    {
        //parentEnemigo.Vidas -= danhoRecibido * multiplicadorDanho;
        //if(parentEnemigo.Vidas <= 0)
        //{
        //    parentEnemigo.Morir();
        //}
    }
}

