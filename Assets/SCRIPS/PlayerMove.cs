using Unity.VisualScripting;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMove : MonoBehaviour
{
    private ControllersGame controller;

    public float speed = 5f;

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
        Correr();
    }

    public void Correr()
    {
        float runValue = controller.PlayerControllers.RUN.ReadValue<float>();

        if (runValue > 0)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            animator.SetBool("RUN", true);
        }
        else
        {
            animator.SetBool("RUN", false);
        }
    }





}
