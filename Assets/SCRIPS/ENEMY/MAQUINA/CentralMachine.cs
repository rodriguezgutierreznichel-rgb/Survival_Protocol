using UnityEngine;
using UnityEngine.AI;

public class CentralMachine : MonoBehaviour
{
    private Estados estadoActual;

    public GameObject enemigo;
    public float distancia;
    public GameObject vista;

    public NavMeshAgent agent;
    public Transform player;

    public Animator animator;

    public Transform[] posiciones;
    public bool persiguiendo = false;
    public float velocidadPatrulla = 2f;

    public Transform Player;
    public float distanciaDeAtaque = 5f;

    public GameObject bala;
    public Transform puntoDeDisparo;
    public float fuerzaDeDisparo = 100f;

    public float tiempoDisponible = 5f;
    public float tiempoDeDisparo = 0f;



    public float probabilidadDeAcierto = 0.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CambiarEstado(new EstadoPatrulla());
    }

    // Update is called once per frame
    void Update()
    {
        if (estadoActual != null)
            estadoActual.Ejecutar(this);
    }

    public void CambiarEstado(Estados nuevo)
    {
       
        if (estadoActual != null)
            estadoActual.Salir(this);

        estadoActual = nuevo; 
        estadoActual.Entrar(this); 
    }

   

    private void OnTriggerStay(Collider other)
    {
       

        Vector3 rotar = player.position - enemigo.transform.position;

        rotar.y = 0;
        enemigo.transform.rotation = Quaternion.LookRotation(rotar);

        persiguiendo = true;
        Vector3 origin = vista.transform.position;
        Vector3 direction = vista.transform.forward * distancia;
        Ray ray = new Ray(origin, direction);
        RaycastHit hit;

        Debug.DrawRay(origin, direction, Color.red);
        if (other.CompareTag("Player") && Physics.Raycast(ray, out hit) && hit.collider.CompareTag("Player"))
        {

            CambiarEstado(new EstadoPerseguir());

        }

        if (Vector3.Distance(transform.position, player.transform.position) <= distanciaDeAtaque)
        {
            //CambiarEstado(new EstadoAtaque());
            Debug.Log("Te ataco");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CambiarEstado(new EstadoPatrulla());
        }
    }
}
