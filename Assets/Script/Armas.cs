using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armas : MonoBehaviour
{

    [SerializeField] private ArmaSO stats;
    [SerializeField] private ParticleSystem system;
    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            system.Play(); //Ejecuto sistema de partículas.
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hitInfo, stats.Alcance))
            {
                if (hitInfo.transform.CompareTag("ParteEnemigo"))
                {
                    hitInfo.transform.GetComponent<EnemigoPartes>().RecibirDanho(stats.danhoAtaque);
                }
            }
        }
    }
}
