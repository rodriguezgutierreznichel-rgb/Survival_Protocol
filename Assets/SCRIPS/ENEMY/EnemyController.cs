using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject target;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float distancia = Vector3.Distance(transform.position, target.transform.position);

    }

    // Update is called once per frame
    void Update()
    {
        ComportamientoDelEnemigo();
    }

    public void ComportamientoDelEnemigo()
    {
        if (Vector3.Distance(transform.position, target.transform.position) > 5)
        {
            Debug.Log("NO TE VEO");
        }
        else
        {
            Debug.Log("TE VI");
        }
    }
}
