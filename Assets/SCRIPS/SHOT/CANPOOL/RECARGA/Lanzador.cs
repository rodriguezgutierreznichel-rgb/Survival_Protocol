using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;


public class Lanzador : MonoBehaviour
{
    private ControllersGame controles;

    //Punto donde saldra la bala
    [SerializeField] Transform puntoDisparo;

    //Fuerza de disparo
    [SerializeField] float shootingForce = 20f;

    //Animaciones
    [SerializeField] Animator animator;

    //Condiciones para disparar
    public float tiempoDisponible = 5f;
    public float tiempoDeDisparo = 0f;
   

    private void Awake()
    {
        controles = new ControllersGame();
    }
    private void OnEnable()
    {
        controles.Enable();

        controles.PlayerControllers.ATTACK.performed += ActivarApuntado;
        controles.PlayerControllers.ATTACK.canceled += DesactivarApuntado;
    }

    private void OnDisable()
    {
        controles.PlayerControllers.ATTACK.performed -= ActivarApuntado;
        controles.PlayerControllers.ATTACK.canceled -= DesactivarApuntado;

        controles.PlayerControllers.SHOOT.performed -= JugadorDispara;

        controles.Disable();
    }

    void JugadorDispara(InputAction.CallbackContext context)
    {

            if ( tiempoDisponible >= tiempoDeDisparo)
            {
                tiempoDisponible = 0;

                GameObject proyectil = CanPool.instance.PopObject();

                if (proyectil != null)
                {
                  proyectil.transform.position = puntoDisparo.position;
                  proyectil.transform.rotation = puntoDisparo.rotation;

                  proyectil.SetActive(true);

                  Rigidbody rb = proyectil.GetComponent<Rigidbody>();

                  rb.AddForce(Camera.main.transform.forward * shootingForce);
                }
            }
       
    }

    void ActivarApuntado(InputAction.CallbackContext context)
    {
        animator.SetBool("ATTACK", true);

        controles.PlayerControllers.SHOOT.performed += JugadorDispara;
    }

    void DesactivarApuntado(InputAction.CallbackContext context)
    {
        animator.SetBool("ATTACK", false);

        controles.PlayerControllers.SHOOT.performed -= JugadorDispara;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && CanPool.instance.maxElements < 6)
        {
            CanPool.instance.Recargar(+3);
        }
        else if (CanPool.instance.maxElements >= 6)
        {
            Debug.Log("Almacenamiento lleno");
        }

        if (tiempoDisponible < tiempoDeDisparo)
        {

            tiempoDisponible += Time.deltaTime;

        }
    }
}
