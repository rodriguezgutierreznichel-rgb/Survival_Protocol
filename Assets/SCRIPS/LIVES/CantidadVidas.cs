
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class CantidadVidas : MonoBehaviour
{
    public static bool playerVivo = true;


    //Vidas
    private int vidasMaximas;
    public Image barraDeVida;
    public int vidas = 3;

   

    

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

        if (gameObject.CompareTag("Player"))
        {
            barraDeVida.fillAmount = (float)vidas / vidasMaximas;

            if (vidas <= 0)
            {
                RecibirDañoPlayer();
            }
        }

        if (gameObject.CompareTag("ENEMIGO"))
        {
            Debug.Log("barra vida");

            if (vidas <= 0)
            {
                RecibirDañoEnemigo();
            }
        }
 
    }

    public void AnimacionCamara()
    {
        Vector3 posicionFinal = camara.transform.localPosition + newPosition;
        LeanTween.moveLocal(camara, posicionFinal, velocidadDeAnimacion).setEase(tipoDeCurvaDelBoton);
    }

    public void RecibirDañoPlayer()
    {
        playerVivo = false;


        AnimacionCamara();

        PlayerController player = GetComponent<PlayerController>();
        if (player != null) player.MuertePlayer();
    }

    public void RecibirDañoEnemigo()
    {
        Puntos.instance.RecibirPuntos(1);
        EnemyController enemy = GetComponent<EnemyController>();
        if (enemy != null) enemy.EnemigoMuerto();
    }
   
    



}
