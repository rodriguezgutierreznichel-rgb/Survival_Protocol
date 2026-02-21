using UnityEngine;
using UnityEngine.Rendering;

public class Bala : MonoBehaviour
{
    private Rigidbody fisicaBalaPlayer;

    public float timer;
    public float tiempoDeDesaparicion;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        fisicaBalaPlayer = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        timer = 0f; // Reinicia el cronómetro cada vez que la bala sale del pool

        fisicaBalaPlayer.linearVelocity = Vector3.zero;
        fisicaBalaPlayer.angularVelocity = Vector3.zero;
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
        if (collision.gameObject.CompareTag("ENEMIGO"))
        {
            Lives.instance.PerderVidasEnemigo(1);
            Debug.Log("Chocó con el enemigo");

            // EN LUGAR DE DESTROY: Devolver a la pool
            RegresarAPool();
        }
    }

    private void RegresarAPool()
    {
        CANPOOL1.instance.PushObject(this.gameObject);
        Debug.Log("Volvio a la piscina");
    }
}
