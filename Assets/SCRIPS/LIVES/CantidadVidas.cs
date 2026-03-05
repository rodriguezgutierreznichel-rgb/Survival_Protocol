using UnityEngine;

public class CantidadVidas : MonoBehaviour
{

   
    public int vidas = 3;
    public void Start()
    {

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
            Debug.Log("MUERTE");

            if (gameObject.CompareTag("ENEMIGO"))
            {
                Puntos.instance.RecibirPuntos(1);
            }
        }

        
    }
}
