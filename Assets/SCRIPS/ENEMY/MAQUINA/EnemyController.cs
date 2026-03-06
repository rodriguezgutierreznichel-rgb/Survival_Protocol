using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    //Enemigos
   
    [SerializeField] CentralMachine enemigos;
    [SerializeField] GameObject rastreadores;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Animator animatorEnemigo;
    private bool yaRegresoAlTrabajo = false; // Variable de control

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!CantidadVidas.playerVivo && !yaRegresoAlTrabajo)
        {
            VolverAlTrabajo();
            yaRegresoAlTrabajo = true; // Solo entra aquí una vez
        }

        // Si el jugador revive en algún momento, reseteamos el flag
        if (CantidadVidas.playerVivo)
        {
            yaRegresoAlTrabajo = false;
        }
    }

    public void EnemigoMuerto()
    {
        Puntos.instance.RecibirPuntos(1);
        animatorEnemigo.SetBool("DEAD", true);
        agent.isStopped = true;
        rastreadores.SetActive(false);

        if (enemigos != null)
        {
            enemigos.enabled = false;
        }

        

    }

    public void VolverAlTrabajo()
    {
        
            CantidadVidas vidasDeEnemigos = enemigos.GetComponent<CantidadVidas>();

            if (vidasDeEnemigos.vidas > 0)
            {
                enemigos.EstadoPatrullar();
                animatorEnemigo.SetFloat("WALKING", agent.velocity.magnitude);
            }

            rastreadores.SetActive(false);

    }
}
