using Unity.VisualScripting;
using UnityEngine;

public class Deteccion : MonoBehaviour
{
    public CentralMachine enemigo;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        enemigo.persiguiendo = true;

        Vector3 rotar = enemigo.player.position - enemigo.transform.position;

        rotar.y = 0;
        enemigo.transform.rotation = Quaternion.LookRotation(rotar);

        //if (Vector3.Distance(transform.position, enemigo.player.transform.position) <= enemigo.distanciaDeAtaque)

        Vector3 origin = enemigo.vista.transform.position;
        Vector3 direction = enemigo.vista.transform.forward * enemigo.distancia;
        Ray ray = new Ray(origin, direction);
        RaycastHit hit;

        Debug.DrawRay(origin, direction, Color.red);
        if (other.CompareTag("Player") && Physics.Raycast(ray, out hit) && hit.collider.CompareTag("Player"))
        {

            float distancia = Vector3.Distance(enemigo.transform.position, enemigo.player.position);
            Debug.Log("La distancia es de: " + distancia);
            if (distancia <= enemigo.distanciaDeAtaque)
            {
                enemigo.EstadoAtacar();
            }
            else
            {
                enemigo.EstadoPerseguir();
            }
           


        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Te perdi");
            enemigo.persiguiendo = false;
            enemigo.EstadoPatrullar();
        }
    }
}
