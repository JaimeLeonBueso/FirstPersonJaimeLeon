using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bazooka : MonoBehaviour
{
    [SerializeField] private GameObject granadaPrefab;
    [SerializeField] private Transform spawnPoint;
   
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //Instanciar una copia del prefab granada en la boca del bazooka.
            Instantiate(granadaPrefab, spawnPoint.position, transform.rotation);
        }
    }
}
