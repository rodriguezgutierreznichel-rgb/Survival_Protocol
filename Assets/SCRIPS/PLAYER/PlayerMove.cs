using Unity.VisualScripting;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMove : MonoBehaviour
{
    private ControllersGame controller;

    public float speedWalking = 5f;
    public float speedRun = 10f;

    [SerializeField]
    Animator animator;

    bool estaAtacando = false;

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
        Disparar();

        if (estaAtacando == false)
        {
            Caminar();
            Correr();
        }
        else
        {
            animator.SetBool("WALKING", false);
            animator.SetBool("RUN", false);
        }
    }

    public void Caminar()
    {
        bool estaCaminando = controller.PlayerControllers.WALKING.IsPressed();

        if (estaCaminando == true)
        {
            
            transform.Translate(Vector3.forward * speedWalking * Time.deltaTime);
            animator.SetBool("WALKING", true);
        }
        else
        {
            animator.SetBool("WALKING", false);
        }
    }

    public void Correr()
    {
        bool estaCorriendo = controller.PlayerControllers.RUN.IsPressed();

        if (estaCorriendo == true)
        {
            transform.Translate(Vector3.forward * speedRun * Time.deltaTime);
            animator.SetBool("RUN", true);
        }
        else
        {
            animator.SetBool("RUN", false);
        }
    }
    

    public void Disparar()
    {
        estaAtacando = controller.PlayerControllers.ATTACK.IsPressed();
        animator.SetBool("ATTACK", estaAtacando);
    }




}
