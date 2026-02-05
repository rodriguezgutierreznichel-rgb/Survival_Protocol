using UnityEngine;
using UnityEngine.AI;
public class EnemyController : MonoBehaviour
{
    public Transform player;

    public GameObject bala;
    public Transform spawnPoint;
    public float fuerzaDeDisparo = 100f;

    public float speed = 3f;
    public float distanciaVision = 15f;
    public float distanciaDeAtaque = 10f;

    [SerializeField]
    Animator animator;

    public float tiempoDisponible = 5f;
    public float tiempoDeDisparo = 0f;
    bool estaDisparando;

    [SerializeField]
    NavMeshAgent agent;
    [SerializeField]
    Transform targetPosition;
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        if (tiempoDisponible < tiempoDeDisparo)
        {

            tiempoDisponible += Time.deltaTime;

        }

        ComportamientoDelEnemigo();
    }

    public void ComportamientoDelEnemigo()
    {
        if (Vector3.Distance(transform.position, player.transform.position) > distanciaVision)
        {
            Debug.Log("NO TE VEO");
            animator.SetBool("RUN", false);
            agent.SetDestination(targetPosition.position);
            animator.SetBool("WALKING", true);
        }
        else
        {
            Debug.Log("TE VI");
            animator.SetBool("RUN", true);
            Perseguir();
           
        }
    }

    public void Perseguir()
    {
        Vector3 direccion = player.position - transform.position; //Calcula la distancia del jugador y de él

        direccion.y = 0;  //El enemigo se queda en el suelo, si estoy en una plataforma no la sube pero si esto si la sube, basicamente la atraviesa o flota
        direccion.Normalize(); //Para que el enemigo vaya a la misma velocidad

       
        transform.forward = direccion; //Mira hacia el jugador

       
        transform.position += direccion * speed * Time.deltaTime; //Va hacia el jugador

        

        if (Vector3.Distance(transform.position, player.transform.position) <= distanciaDeAtaque)
        {
            atacar();
            estaDisparando = true;
        }
        else
        {
            animator.SetBool("ATTACK", false);
        }
    }

    public void atacar()
    {
        if (estaDisparando == true && tiempoDisponible >= tiempoDeDisparo)
        {

            tiempoDisponible = 0;

            GameObject nuevaBala;
            nuevaBala = Instantiate(bala, spawnPoint.position, spawnPoint.rotation);
            nuevaBala.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * fuerzaDeDisparo);

        }
        animator.SetBool("RUN", false); 
        Debug.Log("PIU PIU");
        speed = 0;
        animator.SetBool("ATTACK", true);
    }

   

}
