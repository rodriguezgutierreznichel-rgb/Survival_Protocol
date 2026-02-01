using UnityEngine;
using UnityEngine.Rendering;

public class ShooterSystemPlayer : MonoBehaviour
{
    private ControllersGame controller;

    [SerializeField] GameObject mirilla;

    [SerializeField] GameObject bala;

    [SerializeField] Transform puntoDeDisparo;

    [SerializeField] float fuerzaDeDisparo = 100f;

    [SerializeField] float rotacion = 0.5f;


    bool estaAtacando = false;
    public GameObject pistola;
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

    // Update is called once per frame
    void Update()
    {
        Disparar();
    }

    public void Disparar()
    {
        estaAtacando = controller.PlayerControllers.ATTACK.IsPressed();
        pistola.SetActive(estaAtacando);
        animator.SetBool("ATTACK", estaAtacando);

        bool estaDisparando = controller.PlayerControllers.SHOOT.WasPressedThisFrame();

        if (estaDisparando && estaAtacando)
        {
            GameObject nuevaBala = Instantiate(
                bala,
                puntoDeDisparo.position,
                Quaternion.identity
            );

            Vector3 direccion = (mirilla.transform.position - puntoDeDisparo.position).normalized;

            Rigidbody rb = nuevaBala.GetComponent<Rigidbody>();
            rb.AddForce(direccion * fuerzaDeDisparo, ForceMode.Impulse);

           
        }
    }

   
}
