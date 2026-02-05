using UnityEngine;

public class ENEMIGODETECTAR : MonoBehaviour
{
    public float distanciaMaxima = 10f;

    void Start()
    {
        
    }

    public void Update()
    {
       
    }

    void OnTriggerEnter(Collider other)
    {
        
        Ray ray = new Ray (transform.position, transform.forward);
        RaycastHit hit;
        
        if (other.CompareTag("Player") && Physics.Raycast(ray, out hit, distanciaMaxima) && hit.collider.CompareTag("Player"))
        {
           
            Debug.Log("Te persigo");
        }
    }
}
