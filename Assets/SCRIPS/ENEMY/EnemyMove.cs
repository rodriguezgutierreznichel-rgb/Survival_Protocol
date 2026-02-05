using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] Transform player;

    [SerializeField] NavMeshAgent agent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Detectar();

    }

    public void Detectar()
    {
        Vector3 origen = transform.position + Vector3.up * 1.5f;
        Vector3 direccion = player.position - origen;

        Ray ray = new Ray(origen, direccion);
        RaycastHit hit;



        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.CompareTag("Player"))
            {
                Perseguir();
            }
        }
        else
        {
            Debug.Log("no te veo");
        }
    }

    public void Perseguir()
    {
        agent.SetDestination(player.position);
    }


   // private void OnTriggerEnter(Collider other)
   //{

     //   if (other.CompareTag("Player"))
       // {
         //   Debug.Log("Choco con el player");
        //}
        //Vector3 origen = transform.position + Vector3.up * 1.5f;
        //Vector3 direccion = player.position - origen;

        //Ray ray = new Ray(origen, direccion);
        //RaycastHit hit;

        //if (other.CompareTag("Player") && Physics.Raycast(ray, out hit) && hit.collider.CompareTag("Player"))
        //{
        //  Debug.Log("Te vi");
        //Debug.DrawRay(origen, direccion, Color.red);
        //}
    //}
}
