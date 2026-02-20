using UnityEngine;
using UnityEngine.AI;

public class Lives : MonoBehaviour
{
    public CentralMachine enemigo;

    //Vidas
    public static Lives instance;
    public int vidas = 3;
    public int vidasEnemigo = 3;

    //Player
    [SerializeField] PlayerMove playerMove;
    [SerializeField] Vista vista;
    [SerializeField] VIEW view;
    [SerializeField] Animator animatorPlayer;

    //Camara y sus animaciones
    [SerializeField] GameObject camara;
    [SerializeField] LeanTweenType tipoDeCurvaDelBoton;
    [SerializeField] float velocidadDeAnimacion = 0f;
    [SerializeField] Vector3 posicion = new Vector3 (38f, 0f, 0f);

    //Enemigo
    [SerializeField] Transform muerteEnemigo;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Animator animatorEnemigo;
    [SerializeField] GameObject rastreador;

    
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
            animatorPlayer.SetBool("RUN", false);
            animatorPlayer.SetBool("WALKING", false);
            animatorPlayer.SetBool("BACKWARDS", false);
            animatorPlayer.SetBool("AIM", false);
            animatorPlayer.SetBool("LEFT", false);
            animatorPlayer.SetBool("RIGHT", false);
            rastreador.SetActive(false);
            playerMove.enabled = false;

            
            view.enabled = false;
            agent.isStopped = true;

            LeanTween.rotate(camara, posicion, velocidadDeAnimacion).setEase(tipoDeCurvaDelBoton);

            enemigo.EstadoPatrullar();
        }
    }

    public void PerderVidasEnemigo(int vidasPerdidasEnemigo)
    {

        vidasEnemigo -= vidasPerdidasEnemigo;

        if (vidasEnemigo <= 0)
        {
            
            Debug.Log("Has matado al enemigo");
            animatorEnemigo.SetBool("DEAD", true);
            rastreador.SetActive(false);
            agent.isStopped = true;
        }
    }
}
