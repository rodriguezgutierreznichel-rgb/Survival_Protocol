using UnityEngine;
using UnityEngine.Rendering;

public class ShooterSystemPlayer : MonoBehaviour
{
    private ControllersGame controller;

    public GameObject bala;
    public Transform spawnPoint;
    public float fuerzaDeDisparo = 100f;

    public float tiempoDisponible = 5f;
    public float tiempoDeDisparo = 0f;
    
    public GameObject pistola;

    [SerializeField] Animator animator;

    bool estaAtacando;
    bool estaDisparando;

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
        if (tiempoDisponible < tiempoDeDisparo)
        {
            
            tiempoDisponible += Time.deltaTime;
            
        }

        Disparar();
    }

    public void Disparar()
    {
        estaAtacando = controller.PlayerControllers.ATTACK.IsPressed();
        estaDisparando = controller.PlayerControllers.SHOOT.WasPressedThisFrame();

        if (estaAtacando == true)
        {
            animator.SetBool("ATTACK", true);
            if (estaDisparando == true && tiempoDisponible >= tiempoDeDisparo)
            {
                
                tiempoDisponible = 0;

                GameObject nuevaBala;
                nuevaBala = Instantiate(bala,spawnPoint.position, spawnPoint.rotation);
                nuevaBala.GetComponent<Rigidbody>().AddForce(spawnPoint.forward*fuerzaDeDisparo);
                
            }
        }
        else
        {
            animator.SetBool("ATTACK", false);
        }
    }
   
}
