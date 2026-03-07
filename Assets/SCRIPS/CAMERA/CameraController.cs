using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Camara y sus animaciones
    [SerializeField] GameObject camara;
    [SerializeField] LeanTweenType tipoDeCurvaDelBoton;
    [SerializeField] float velocidadDeAnimacion = 0f;
    [SerializeField] Vector3 newPosition = new Vector3(0f, 0f, -5f);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
