using UnityEngine;

public class RecibirMunicion : MonoBehaviour
{
    [SerializeField] int cantidadBalas = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Usamos el método Recargar que ya tenías en tu CanPool original
            if (CanPool.instance != null)
            {
                CanPool.instance.Recargar(cantidadBalas);
            }

            // Regresa el cubo al pool de munición
            PoolMunicion.instance.RegresarAlPool(this.gameObject);
        }
    }
}
