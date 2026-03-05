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
    }
}
