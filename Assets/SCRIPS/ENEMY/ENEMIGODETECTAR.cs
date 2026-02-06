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


    void Start()
    {
        
    }

    public void Update()
    {
       
    }

    void OnTriggerStay(Collider other)
    {
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
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool("RUN", false);
            
            Debug.Log("Te perdí");
        }
    }
}
