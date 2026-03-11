using UnityEngine;

public class SpawnearEnemigos : MonoBehaviour
{
    [SerializeField] Transform[] posiciones;
    private int oldPosition;

    public float enemigosPermitidos = 3;
    public float enemigosActuales;
    private bool puedeSpawnear = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemigosActuales < enemigosPermitidos && puedeSpawnear == true)
        {

            GameObject nuevoEnemigo = PoolEnemigos.instance.popObjects();

            if (nuevoEnemigo != null)
            {
                int randomPosition = Random.Range(0, posiciones.Length);

                while (randomPosition == oldPosition)
                {
                    randomPosition = Random.Range(0, posiciones.Length);
                }

                oldPosition = randomPosition;

                enemigosActuales++;

                if (enemigosActuales >= enemigosPermitidos)
                {
                    puedeSpawnear = false;
                }

                Debug.Log("el nuevo enemigo esta " + posiciones[randomPosition].name);

                nuevoEnemigo.transform.position = posiciones[randomPosition].position;

                nuevoEnemigo.SetActive(true);
            }
        }
    }

    public void EnemigosEliminados()
    {
        if (enemigosActuales > 0)
        {
            enemigosActuales--;
        }

        if (enemigosActuales <= 0)
        {
            puedeSpawnear = true;
            Debug.Log("¡Todos muertos! Reiniciando Spawner...");
        }

        
    }
}
