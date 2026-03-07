using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    //Enemigos
    public int CantidadDePuntos = 1;
    [SerializeField] CentralMachine enemigos;
    public GameObject rastreadores;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Animator animatorEnemigo;
    private bool yaRegresoAlTrabajo = false; // Variable de control
   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CantidadVidas.playerVivo = true;
        CantidadVidas.playerMuerto = false;

        if (rastreadores != null)
        {
            rastreadores.SetActive(true);
        }
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


        Puntos.instance.RecibirPuntos(CantidadDePuntos);
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
            // Si el jugador está muerto, apagamos la visión
            if (CantidadVidas.playerVivo == false)
            {
                enemigos.EstadoPatrullar();
                animatorEnemigo.SetFloat("WALKING", agent.velocity.magnitude);
                rastreadores.SetActive(false);
            }
            else
            {
                // Si el jugador está vivo (al reiniciar), la encendemos
                rastreadores.SetActive(true);
            }
        }




    }

    
}
