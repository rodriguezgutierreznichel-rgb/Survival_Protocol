using UnityEngine;
using UnityEngine.AI;

public class Lives : MonoBehaviour
{
    public CentralMachine enemigo;
    public static Lives instance;
    public int vidas = 3;
    public int vidasEnemigo = 3;

    [SerializeField] Animator animatorEnemigo;
    [SerializeField] Animator animatorPlayer;

    [SerializeField] GameObject rastreador;

    [SerializeField] PlayerMove playerMove;
    [SerializeField] Vista vista;
    [SerializeField] VIEW view;

    
    [SerializeField] Transform muerteEnemigo;
    [SerializeField] NavMeshAgent agent;

    bool enemigoMuerto = false;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PerderVidas(int vidasPerdidas)
    {
        vidas = vidas - vidasPerdidas;

        if (vidas <= 0)
        {
            Debug.Log("Has muerto");
            animatorPlayer.SetBool("DEAD", true);   
            rastreador.SetActive(false);
            playerMove.enabled = false;
            vista.enabled = false;
            view.enabled = false;
            agent.isStopped = true;

            enemigo.EstadoPatrullar();
        }
    }

    public void PerderVidasEnemigo(int vidasPerdidasEnemigo)
    {

        vidasEnemigo -= vidasPerdidasEnemigo;

        if (vidasEnemigo <= 0)
        {
            enemigoMuerto = true;
            Debug.Log("Has matado al enemigo");
            animatorEnemigo.SetBool("DEAD", true);
            rastreador.SetActive(false);
            agent.isStopped = true;
        }
    }
}
