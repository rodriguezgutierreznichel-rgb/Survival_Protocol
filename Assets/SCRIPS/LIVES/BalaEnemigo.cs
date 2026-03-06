using UnityEngine;

public class BalaEnemigo : MonoBehaviour
{
    private Rigidbody fisicaBalaEnemigo;
    [SerializeField] string tagTarget = "Player";
    public float timer;
    public float tiempoDeDesaparicion;

    void Awake()
    {
        fisicaBalaEnemigo = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        timer = 0f;
        fisicaBalaEnemigo.linearVelocity = Vector3.zero;
        fisicaBalaEnemigo.angularVelocity = Vector3.zero;
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
        // 1. Detectamos si chocamos con el Player
        if (collision.gameObject.CompareTag("Player"))
        {
            // 2. Intentamos obtener el script de vidas del objeto chocado
            CantidadVidas vidasPlayer = collision.gameObject.GetComponent<CantidadVidas>();

            // 3. Verificamos si el componente existe antes de usarlo
            if (vidasPlayer != null)
            {
                vidasPlayer.RecibirDaño();
                Debug.Log("El Player ahora tiene: " + vidasPlayer.vidas + " vidas.");
            }

            RegresarAPool();
        }
    }

    private void RegresarAPool()
    {
        // Usamos el método de tu pool para balas enemigas
        CANPOOL1.instance.PushEnemigo(this.gameObject);
        Debug.Log("Bala enemiga regresó a la piscina");
    }
}
