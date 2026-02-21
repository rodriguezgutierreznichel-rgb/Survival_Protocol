using UnityEngine;

public class BalaEnemigo : MonoBehaviour
{
    private Rigidbody fisicaBalaEnemigo;

    public float timer;
    public float tiempoDeDesaparicion;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        fisicaBalaEnemigo = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        timer = 0f; // Reinicia el cronómetro cada vez que la bala sale del pool

        fisicaBalaEnemigo.linearVelocity = Vector3.zero;
        fisicaBalaEnemigo.angularVelocity = Vector3.zero;
    }


    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;

        if (timer >= tiempoDeDesaparicion)
        {
            // EN LUGAR DE DESTROY: Devolver a la pool
            RegresarAPool();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Lives.instance.PerderVidas(1);
            Debug.Log("Chocó con el player");
            RegresarAPool();
        }
    }
    private void RegresarAPool()
    {
        CANPOOL1.instance.PushEnemigo(this.gameObject);
        Debug.Log("Volvio a la piscina");
    }
}
