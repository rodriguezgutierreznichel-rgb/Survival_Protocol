using UnityEngine;
using UnityEngine.Rendering;

public class Bala : MonoBehaviour
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
        if (collision.gameObject.CompareTag("ENEMIGO"))
        {
            Lives.instance.PerderVidasEnemigo(1);
            Debug.Log("Chocó con el enemigo");
            Destroy(gameObject);
        }
    }
}
