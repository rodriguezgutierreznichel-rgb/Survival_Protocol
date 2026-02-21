using Unity.VisualScripting;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMove : MonoBehaviour
{
    private ControllersGame controller;

    //Velocidades
    public float speedWalking = 5f;
    public float speedRun = 10f;

    //Animaciones
    [SerializeField]
    Animator animator;

    private void Awake()
    {
        
        controller = new ControllersGame();
    }

    private void OnEnable()
    {
        controller.Enable();
    }
    private void OnDisable()
    {
        controller.Disable();
    }

    public void Update()
    {
        Caminar();
        CaminarHaciaAtras();
        CaminarHaciaLaIzquierda();
        CaminarHaciaLaDerecha();
    }

    public void Caminar()
    {
        bool estaCaminando = controller.PlayerControllers.WALKING.IsPressed();
        bool estaCorriendo = controller.PlayerControllers.RUN.IsPressed();

        if (estaCaminando)
        {
            float velocidadActual = speedWalking;

            if (estaCorriendo == true)
            {
                velocidadActual = speedRun;
                animator.SetBool("RUN", true);
            }
            else
            {
                animator.SetBool("RUN", false);
            }

            transform.Translate(Vector3.forward * velocidadActual * Time.deltaTime);
            animator.SetBool("WALKING", true);
        }
        else
        {
            animator.SetBool("WALKING", false);
            animator.SetBool("RUN", false);
        }
    }

    public void CaminarHaciaAtras()
    {
        bool estaCaminandoHaciaAtras = controller.PlayerControllers.BACKWARDS.IsPressed();

        if (estaCaminandoHaciaAtras == true)
        {
            animator.SetBool("BACKWARDS", true);
            transform.Translate(Vector3.back * speedWalking * Time.deltaTime);
        }
        else
        {
            animator.SetBool("BACKWARDS", false);
        }
    }

    public void CaminarHaciaLaIzquierda()
    {
        bool estaCaminandoHaciaLaIzquierda = controller.PlayerControllers.LEFT.IsPressed();

        if (estaCaminandoHaciaLaIzquierda == true)
        {
            animator.SetBool("LEFT", true);
            transform.Translate(Vector3.left * speedWalking * Time.deltaTime);
        }
        else
        {
            animator.SetBool("LEFT", false);
        }
    }

    public void CaminarHaciaLaDerecha()
    {
        bool estaCaminandoHaciaLaDerecha = controller.PlayerControllers.RIGHT.IsPressed();

        if (estaCaminandoHaciaLaDerecha == true)
        {
            animator.SetBool("RIGHT", true);
            transform.Translate(Vector3.right * speedWalking * Time.deltaTime);
        }
        else
        {
            animator.SetBool("RIGHT", false);
        }
    }
}
