using UnityEngine;
using UnityEngine.AI;
public class EnemyController : MonoBehaviour
{
    public GameObject target;
    public Transform player;

    public float speed = 3f;
    public float distanciaVision = 5f;
    public float distanciaDeAtaque = 10f;

    [SerializeField]
    Animator animator;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float distancia = Vector3.Distance(transform.position, target.transform.position);


    }

    public void Update()
    {
        
    }

    public void ComportamientoDelEnemigo()
    {
        if (Vector3.Distance(transform.position, target.transform.position) > 5)
            if (Vector3.Distance(transform.position, player.transform.position) > distanciaVision)
            {
                Debug.Log("NO TE VEO");
                animator.SetBool("RUN", false);
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
        }
    }

    public void atacar()
    {
        Debug.Log("TE ATACO MALDITO");
    }


}
