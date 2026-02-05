using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] Transform player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       

    }

    private void OnTriggerEnter(Collider other)
    {
        Vector3 direccion = player.position - transform.position;

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (other.CompareTag("Player") && Physics.Raycast(ray, out hit) && (hit.collider. CompareTag("Player")))
        {
            Debug.Log("Te vi");
            Debug.DrawRay((transform.position), direccion, Color.red);
        }
    }
}
