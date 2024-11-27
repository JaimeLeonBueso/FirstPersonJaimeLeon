using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Personaje : MonoBehaviour
{

    [SerializeField] private float vidas;

    [Header("Movimiento")]
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private float factorGravedad;
    [SerializeField] private float alturaSalto;

    [Header("Detección suelo")]
    [SerializeField] private float radioDeteccion;
    [SerializeField] private Transform pies;
    [SerializeField] private LayerMask queEsSuelo;

  
    private CharacterController characterController;
    private Vector3 movimientoVertical;

   

    void Start()
    {
       characterController = GetComponent<CharacterController>();
       Cursor.lockState = CursorLockMode.Locked;

    }

    
    void Update()
    {
        MoverYRotar();
        AplicarGravedad();
     if (EnSuelo())
        {
            movimientoVertical.y = 0;
            Saltar();
        }
   
    }
    void MoverYRotar()
    {
       float h = Input.GetAxisRaw("Horizontal");
       float v = Input.GetAxisRaw("Vertical");
        
       Vector2 inputMovimiento = new Vector2(h, v).normalized;

       transform.rotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y , 0);

        if (inputMovimiento.magnitude > 0)
        {
            float anguloRotacion = Mathf.Atan2(inputMovimiento.x, inputMovimiento.y) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
            transform.eulerAngles = new Vector3(0, anguloRotacion, 0);

            Vector3 movimiento = Quaternion.Euler(0, anguloRotacion, 0) * Vector3.forward;
            characterController.Move(movimiento *velocidadMovimiento *Time.deltaTime);
        }
    }


    private void AplicarGravedad()
    {
        movimientoVertical.y += factorGravedad * Time.deltaTime;
        characterController.Move(movimientoVertical * Time.deltaTime);
    }

   
    private bool EnSuelo()
    {
        //Tirar una esfera de detección en los piescon cierto radio
        bool resultado = Physics.CheckSphere(pies.position, radioDeteccion, queEsSuelo);
        return resultado;
    }

  
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(pies.position, radioDeteccion);
        Gizmos.DrawWireSphere(pies.position, radioDeteccion);
    }
   


    private void Saltar()
    {
       
        if (Input.GetKeyDown(KeyCode.Space))
        {
            movimientoVertical.y = Mathf.Sqrt(-2 * factorGravedad * alturaSalto);
        }
    }

   

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
       if(hit.gameObject.CompareTag("ParteEnemigo"))
        {
            Vector3 vectorPush = hit.gameObject.transform.position - transform.position;
            hit.gameObject.GetComponent<Rigidbody>().AddForce(vectorPush.normalized * 100, ForceMode.Impulse);
        }
    }
   

    public void RecibirDanho(float danhoEnemigo)
    {
        vidas -= danhoEnemigo;
    }
}
