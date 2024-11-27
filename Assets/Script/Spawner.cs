using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemigoPrefab;
    [SerializeField] private Transform[] puntosSpawn;
    [SerializeField] private int numeroNiveles;
    [SerializeField] private int rondasPorNivel;
    [SerializeField] private int spawnsPorRonda;
    [SerializeField] private float esperaEntreSpawns;
    [SerializeField] private float esperaEntreRondas;
    [SerializeField] private float esperaEntreNiveles;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawnear());
    }

    // Update is called once per frame
    void Update()
    {
     
    }
    private IEnumerator Spawnear()
    {
        for (int i = 0; i < numeroNiveles; i++) //Niveles (5)
        {
            for (int j = 0; j < rondasPorNivel; j++) //Rondas (5)
            {
                for (int k = 0; k < spawnsPorRonda; k++) //Spawns (10)
                {
                    int indiceAleatorio = Random.Range(0, puntosSpawn.Length);
                    Instantiate(enemigoPrefab, puntosSpawn[indiceAleatorio].position, Quaternion.identity);
                    

                    yield return new WaitForSeconds(esperaEntreSpawns);
                }

                //Actualizar texto de ronda
                yield return new WaitForSeconds(esperaEntreRondas);
            }

            //Actualizar texto de nuevo nivel
            yield return new WaitForSeconds(esperaEntreNiveles);
            
        }
    
    }

    private IEnumerator Patrullar()
    {
        while (true)
        {
            //Ir al punto A
            //Se espera 2 segundos.
            //Ir al punto B
            //Se espera 3 segundos
            //Ir al punto C
            //Se espera 3.5 segundos
        }
    }
}
