
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class CantidadVidas : MonoBehaviour
{

    //Vidas
    private int vidasMaximas;
    public Image barraDeVida;
    public int vidas = 3;

    //Enemigos
    [SerializeField] CentralMachine[] enemigos;
    [SerializeField] GameObject[] rastreadores;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Animator animatorEnemigo;

    //Player
    [SerializeField] Animator animatorPlayer;
    [SerializeField] PlayerMove playerMove;
    [SerializeField] VIEW view;

    //Camara y sus animaciones
    [SerializeField] GameObject camara;
    [SerializeField] LeanTweenType tipoDeCurvaDelBoton;
    [SerializeField] float velocidadDeAnimacion = 0f;
    [SerializeField] Vector3 newPosition = new Vector3(0f, 0f, -5f);

    public void Start()
    {
        vidasMaximas = vidas;
    }


    // Update is called once per frame
    void Update()
    {

    }

    public void RecibirDaño()
    {
        vidas--;
       

        if (vidas <= 0)
        {
            if (gameObject.CompareTag("Player"))
            {
                barraDeVida.fillAmount = (float)vidas / vidasMaximas;
                AnimacionCamara();
                VolverAlTrabajo();
                animatorPlayer.SetBool("DEAD", true);
                playerMove.enabled = false;
                view.enabled = false;
            }

            if (gameObject.CompareTag("ENEMIGO"))
            {
                Puntos.instance.RecibirPuntos(1);
                animatorEnemigo.SetBool("DEAD", true);
                agent.isStopped = true;
                for (int i = 0; i < rastreadores.Length; i++)
                {

                    rastreadores[i].SetActive(false);

                }
            }
        }

        
    }

    public void AnimacionCamara()
    {
        Vector3 posicionFinal = camara.transform.localPosition + newPosition;
        LeanTween.moveLocal(camara, posicionFinal, velocidadDeAnimacion).setEase(tipoDeCurvaDelBoton);
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
