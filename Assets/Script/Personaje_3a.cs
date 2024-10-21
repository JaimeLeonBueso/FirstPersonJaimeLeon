using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Personaje_3a : MonoBehaviour
{
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] CharacterController characterController;
    [SerializeField] private float suavizadoAngulo;
    private float velocidadRotacion;

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
      

        if (inputMovimiento.magnitude > 0)
        {
            float anguloRotacion = Mathf.Atan2(inputMovimiento.x, inputMovimiento.y) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
            float anguloSuavizado = Mathf.SmoothDampAngle(transform.eulerAngles.y, anguloRotacion, ref velocidadRotacion, suavizadoAngulo);
            transform.eulerAngles = new Vector3(0, anguloSuavizado, 0);
            Vector3 movimiento = Quaternion.Euler(0, anguloRotacion, 0) * Vector3.forward;
            characterController.Move(movimiento * velocidadMovimiento * Time.deltaTime);
        }
    }
}
