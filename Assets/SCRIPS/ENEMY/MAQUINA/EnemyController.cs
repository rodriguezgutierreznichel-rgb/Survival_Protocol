using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    //Enemigos
    [SerializeField] CentralMachine[] enemigos;
    [SerializeField] GameObject[] rastreadores;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Animator animatorEnemigo;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnemigoMuerto()
    {
        Puntos.instance.RecibirPuntos(1);
        animatorEnemigo.SetBool("DEAD", true);
        agent.isStopped = true;
        for (int i = 0; i < rastreadores.Length; i++)
        {

            rastreadores[i].SetActive(false);

        }
    }

    public void VolverAlTrabajo()
    {
        for (int e = 0; e < enemigos.Length; e++)
        {
            CantidadVidas vidasDeEnemigos = enemigos[e].GetComponent<CantidadVidas>();

            if (vidasDeEnemigos.vidas > 0)
            {
                enemigos[e].EstadoPatrullar();
            }


        }

        for (int i = 0; i < rastreadores.Length; i++)
        {

            rastreadores[i].SetActive(false);

        }
    }
}
