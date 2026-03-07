
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class CantidadVidas : MonoBehaviour
{
    public static bool playerVivo = true;
    public static bool playerMuerto = false;


    //Vidas
    private int vidasMaximas;
    public Image barraDeVida;
    public int vidas = 3;

   

    

   

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

   

    public void RecibirDañoPlayer()
    {
        playerVivo = false;
        playerMuerto = true;

        CamaraAnimacion animacionDeLaCamara = GetComponent<CamaraAnimacion>();
        animacionDeLaCamara.AnimacionCamara();

        PlayerController player = GetComponent<PlayerController>();
        if (player != null) player.MuertePlayer();
    }

    public void RecibirDañoEnemigo()
    {
        EnemyController enemy = GetComponent<EnemyController>();
        if (enemy != null) enemy.EnemigoMuerto();
    }
   
    



}
