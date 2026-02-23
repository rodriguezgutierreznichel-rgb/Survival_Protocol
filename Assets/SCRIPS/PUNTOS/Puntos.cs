using UnityEngine;
using TMPro;
public class Puntos : MonoBehaviour
{
    public static Puntos instance;
    public int puntos;
    public int puntosNecesarios = 3;

    [SerializeField] TextMeshProUGUI puntosText;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
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
        puntosText.text = "Enemigos derrotados " + puntos;
    }

    public void RecibirPuntos(int puntosRecibidos)
    {
        puntos =+ puntosRecibidos;

        Debug.Log("Puntos actuales " + puntos);

        if (puntos == puntosNecesarios)
        {
            Debug.Log("Has ganado");
        }
    }
}
