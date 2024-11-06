using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armas : MonoBehaviour
{

    [SerializeField] private ArmaSO stats;
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
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hitInfo, stats.Alcance))
            {

            }
        }
    }
}
