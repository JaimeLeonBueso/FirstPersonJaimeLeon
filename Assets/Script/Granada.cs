using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granada : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] private float fuerzaImpulso;

    [Header("Explosión")]
    [SerializeField] private float radioExplosion;
    [SerializeField] private float fuerzaExplosion;
    [SerializeField] private GameObject explosion;
    [SerializeField] private LayerMask queEsExplotable;

    private Collider[] buffer = new Collider[100];

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * fuerzaImpulso, ForceMode.Impulse);
        Destroy(gameObject, 1.5f);
    }


    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
    //Se ejecuta automáticamente cuando esta entidad (granada) se va a morir
    private void OnDestroy()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);

        //Si este if se cumple, la granada ha detectado AL MENOS UN COLLIDER en la capa "queEsExplotable.
        int numeroDetectados = Physics.OverlapSphereNonAlloc(transform.position, radioExplosion, buffer, queEsExplotable);

        //Si el número de detecciones es superior a 0...
        if(numeroDetectados > 0)
        {
            //Recorrer todos los colliders detectados....
            for (int i = 0; i < numeroDetectados; i++)
            {
                //Y por cada collider detectado (huesos), voy a coger el script de cada uno.
                if(buffer[i].TryGetComponent(out EnemigoPartes scriptHueso))
                {
                    scriptHueso.Explotar(fuerzaExplosion, transform.position, radioExplosion, 3.5f);
                }
            }
        }

    }
}
