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




    void Start()
    {
        persiguiendo = false;
    }

    public void Update()
    {
        if (persiguiendo == false)
        {
            patrullar();
        }

      
    }

    public void patrullar()
    {
        animator.SetBool("WALKING", true);
        agent.SetDestination(posiciones[0].position);
        
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
            agent.SetDestination(player.position);
            Debug.Log("Te persigo");
            animator.SetBool("RUN", true);
            animator.SetBool("WALKING", false);
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
}
