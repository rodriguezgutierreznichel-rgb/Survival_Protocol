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

    
    

   




}
