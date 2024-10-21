using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] CharacterController characterController;
 
    void Start()
    {
       characterController = GetComponent<CharacterController>();
    }

    
    void Update()
    {
        MoverYRotar();
    }
    void MoverYRotar()
    {
       float h = Input.GetAxisRaw("Horizontal");
       float v = Input.GetAxisRaw("Vertical");
        
       Vector2 inputMovimiento = new Vector2(h, v).normalized;
       float anguloRotacion = Mathf.Atan2(inputMovimiento.x, inputMovimiento.y) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
       transform.eulerAngles = new Vector3(0, anguloRotacion, 0);

        if (inputMovimiento.magnitude > 0)
        {
            Vector3 movimiento = Quaternion.Euler(0, anguloRotacion, 0) * Vector3.forward;
            characterController.Move(movimiento *velocidadMovimiento *Time.deltaTime);
        }
    }
}
