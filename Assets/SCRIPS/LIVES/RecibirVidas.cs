using UnityEngine;

public class RecibirVidas : MonoBehaviour
{
    [SerializeField] int cantidadCuracion = 1;

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
        
        
            // Verifica si el jugador es quien toca el cubo
            if (other.CompareTag("Player"))
            {
                // Curamos al jugador usando tu Singleton de Lives
                if (Lives.instance != null)
                {
                    // Suponiendo que quieres sumar vida:
                    Lives.instance.vidas += cantidadCuracion;
                    Debug.Log("Vida recuperada. Total: " + Lives.instance.vidas);
                }

                // Regresa el cubo al pool en lugar de destruirlo
                PoolVidas.instance.RegresarAlPool(this.gameObject);
            }
        
    }
}
