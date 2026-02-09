using UnityEngine;

public class BalaEnemigo : MonoBehaviour
{
    public float timer;
    public float tiempoDeDesaparicion;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;

        if (timer >= tiempoDeDesaparicion)
        {

            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Lives.instance.PerderVidas(1);
            Debug.Log("Chocó con el player");
            Destroy(gameObject);
        }
    }
}
