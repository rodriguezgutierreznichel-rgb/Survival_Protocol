using UnityEngine;
using UnityEngine.Rendering;

public class Bala : MonoBehaviour
{
    private Rigidbody fisicaBalaPlayer;
    public float timer;
    public float tiempoDeDesaparicion;
    public int daño = 1; // Nueva variable para controlar cuánto quita cada bala

    void Awake()
    {
        fisicaBalaPlayer = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        timer = 0f;
        fisicaBalaPlayer.linearVelocity = Vector3.zero;
        fisicaBalaPlayer.angularVelocity = Vector3.zero;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= tiempoDeDesaparicion)
        {
            RegresarAPool();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("ENEMIGO"))
        {
            
            CantidadVidas vidasEnemigo = collision.gameObject.GetComponent<CantidadVidas>();

            
            if (vidasEnemigo != null)
            {
                vidasEnemigo.RecibirDaño();
                Debug.Log("Vida restante del enemigo: " + vidasEnemigo.vidas);
            }

            RegresarAPool();
        }
    }

    private void RegresarAPool()
    {
        CANPOOL1.instance.PushObject(this.gameObject);
        Debug.Log("Volvió a la piscina");
    }

}
