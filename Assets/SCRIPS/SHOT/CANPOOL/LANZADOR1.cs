using UnityEngine;
using UnityEngine.InputSystem;

public class LANZADOR1 : MonoBehaviour
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

    //Efecto de disparo
    [SerializeField] GameObject efecto;   
    private float tiempoDesapareciónEffect = 0.5f;



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

        if (tiempoDisponible >= tiempoDeDisparo)
        {
            tiempoDisponible = 0;

            

            GameObject proyectil = CANPOOL1.instance.PopObject();

            if (proyectil != null)
            {
                proyectil.transform.position = puntoDisparo.position;
                proyectil.transform.rotation = puntoDisparo.rotation;

                proyectil.SetActive(true);

                GameObject flash = Instantiate(efecto, puntoDisparo.position, puntoDisparo.rotation);
                Destroy(flash, tiempoDesapareciónEffect);

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
        

        if (tiempoDisponible < tiempoDeDisparo)
        {

            tiempoDisponible += Time.deltaTime;

        }
    }
}
