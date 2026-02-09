using UnityEngine;
using UnityEngine.AI;

public class ENEMIGODETECTAR : MonoBehaviour
{
    [SerializeField] GameObject enemigo;
    [SerializeField] float distancia;
    [SerializeField] GameObject vista;

    [SerializeField] NavMeshAgent agent;
    [SerializeField] Transform player;

    [SerializeField] Animator animator;

    [SerializeField] Transform[] posiciones;
    bool persiguiendo = false;
    [SerializeField] float velocidadPatrulla = 2f;

    [SerializeField] Transform Player;
    [SerializeField] float distanciaDeAtaque = 5f;

    public GameObject bala;
    public Transform puntoDeDisparo;
    public float fuerzaDeDisparo = 100f;
    
    public float tiempoDisponible = 5f;
    public float tiempoDeDisparo = 0f;
    float siguienteDisparo = 0f;
    public float tiempoEntreDisparos = 1.5f;

    public float probabilidadDeAcierto = 0.5f;

    void Start()
    {
        persiguiendo = false;
    }

    public void Update()
    {
        //if (persiguiendo == false)
        //{
          //  patrullar();
        //}

      
    }

    public void patrullar()
    {
        //animator.SetBool("WALKING", true);
       // agent.SetDestination(posiciones[0].position);
        
    }

    void OnTriggerStay(Collider other)
    {
        persiguiendo = true;
       
        Vector3 rotar = player.position - enemigo.transform.position;
        rotar.y = 0;
        enemigo.transform.rotation = Quaternion.LookRotation(rotar);


        Vector3 origin = vista.transform.position;
        Vector3 direction = vista.transform.forward * distancia;
        Ray ray = new Ray (origin, direction);
        RaycastHit hit;

        Debug.DrawRay(origin, direction, Color.red);
        if (other.CompareTag("Player") && Physics.Raycast(ray, out hit) && hit.collider.CompareTag("Player"))
        {
            perseguir();

            if (Vector3.Distance(transform.position, player.transform.position) <= distanciaDeAtaque)
            {
                Atacar();
            }
            else
            {
                perseguir();
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool("RUN", false);
            
            Debug.Log("Te perdí");
            persiguiendo = false;
        }
    }

    public void Atacar()
    {
        agent.isStopped = true;
        animator.SetBool("RUN", false);
        animator.SetBool("ATTACK", true);
        animator.SetBool("WALKING", false);
        Debug.Log("Te ataco");
        

        if (Time.time >= siguienteDisparo)
        {
            siguienteDisparo = Time.time + tiempoEntreDisparos;
            Disparar();
        }
    }

    void Disparar()
    {
        GameObject nuevaBala = Instantiate(bala, puntoDeDisparo.position, puntoDeDisparo.rotation);
        Rigidbody rb = nuevaBala.GetComponent<Rigidbody>();

        Vector3 direccion = puntoDeDisparo.forward;

        // 50% de probabilidad
        if (Random.value > probabilidadDeAcierto)
        {
            // Falla: desviamos el disparo
            direccion += new Vector3(1f, 0f, 0f);
        }

        rb.AddForce(direccion.normalized * fuerzaDeDisparo, ForceMode.Impulse);
    }

    public void perseguir()
    {
        agent.SetDestination(player.position);
        Debug.Log("Te persigo");
        animator.SetBool("RUN", true);
        animator.SetBool("WALKING", false);
        
    }
}
