using UnityEngine;
using UnityEngine.AI;

public class Lives : MonoBehaviour
{
    public CentralMachine enemigo;

    //Vidas
    public static Lives instance;
    public int vidas = 3;
    public int vidasEnemigo = 3;
    public int vidasEnemigo2 = 3;
    public int vidasEnemigo3 = 3;

    //Player
    [SerializeField] PlayerMove playerMove;
    [SerializeField] Vista vista;
    [SerializeField] VIEW view;
    [SerializeField] Animator animatorPlayer;

    //Camara y sus animaciones
    [SerializeField] GameObject camara;
    [SerializeField] LeanTweenType tipoDeCurvaDelBoton;
    [SerializeField] float velocidadDeAnimacion = 0f;
    [SerializeField] float posicionY = 20f;
    [SerializeField] Vector3 rotacion = new Vector3(38f, 0f, 0f);

    //Enemigos
    [SerializeField] Transform muerteEnemigo;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] NavMeshAgent agent2;
    [SerializeField] NavMeshAgent agent3;
    [SerializeField] Animator animatorEnemigo;
    [SerializeField] Animator animatorEnemigo2;
    [SerializeField] Animator animatorEnemigo3;
    [SerializeField] GameObject rastreador;
    [SerializeField] GameObject rastreador2;
    [SerializeField] GameObject rastreador3;




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

            LeanTween.rotate(camara, rotacion, velocidadDeAnimacion).setEase(tipoDeCurvaDelBoton);
            LeanTween.moveY(camara, posicionY, velocidadDeAnimacion).setEase(tipoDeCurvaDelBoton);

            enemigo.EstadoPatrullar();
        }
    }

    public void PerderVidasEnemigo(int vidasPerdidasEnemigo)
    {

        vidasEnemigo -= vidasPerdidasEnemigo;

        if (vidasEnemigo <= 0)
        {
            Puntos.instance.RecibirPuntos(+1);
            Debug.Log("Has matado al enemigo");
            animatorEnemigo.SetBool("DEAD", true);
            rastreador.SetActive(false);
            agent.isStopped = true;

            if (PoolVidas.instance != null)
            {
                PoolVidas.instance.SoltarVida(animatorEnemigo.transform.position + Vector3.up);
            }
        }
    }

    public void PerderVidasEnemigo2(int vidasPerdidasEnemigo2)
    {

        vidasEnemigo2 -= vidasPerdidasEnemigo2;

        if (vidasEnemigo2 <= 0)
        {
            Puntos.instance.RecibirPuntos(+1);
            Debug.Log("Has matado al enemigo");
            animatorEnemigo2.SetBool("DEAD", true);
            rastreador2.SetActive(false);
            agent2.isStopped = true;

            if (PoolVidas.instance != null)
            {
                PoolVidas.instance.SoltarVida(animatorEnemigo.transform.position + Vector3.up);
            }
        }
    }

    public void PerderVidasEnemigo3(int vidasPerdidasEnemigo3)
    {

        vidasEnemigo3 -= vidasPerdidasEnemigo3;

        if (vidasEnemigo3 <= 0)
        {
            Puntos.instance.RecibirPuntos(+1);
            Debug.Log("Has matado al enemigo");
            animatorEnemigo3.SetBool("DEAD", true);
            rastreador3.SetActive(false);
            agent3.isStopped = true;

            if (PoolVidas.instance != null)
            {
                PoolVidas.instance.SoltarVida(animatorEnemigo.transform.position + Vector3.up);
            }
        }
    }
}
