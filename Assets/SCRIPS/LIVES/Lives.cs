using UnityEngine;

public class Lives : MonoBehaviour
{
    public static Lives instance;
    public int vidas = 3;
    public int vidasEnemigo = 3;

    [SerializeField] Animator animatorEnemigo;
    [SerializeField] Animator animatorPlayer;

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
        }
    }
}
