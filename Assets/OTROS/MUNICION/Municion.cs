using UnityEngine;

public class Municion : MonoBehaviour
{
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
        if (other.CompareTag("Player"))
        {
            CanPool.instance.Recargar(+1);
            RegresarAPool();
        }
    }

    private void RegresarAPool()
    {
        // Usamos el método específico para ítems, NO el de balas
        CanPool.instance.PushItemMunicion(this.gameObject);
        Debug.Log("Cubo de munición guardado en su propio pool");
    }
}
