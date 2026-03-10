using UnityEngine;

public class VIEW : MonoBehaviour
{
    //Sensibilidad y rotacion para mover la camara con el raton
    public float sensibilidad = 200f;
    float rotY = 0f;


    //Controles para mover la camara con el mando
    private ControllersGame controls;

    //Valores de entrada del movimiento de la mirada (mando o raton)
    private Vector2 lookInput;

   

    void Awake()
    {
        controls = new ControllersGame();

        controls.PlayerControllers.VIEW.performed += informacion => lookInput = informacion.ReadValue<Vector2>();
        controls.PlayerControllers.VIEW.canceled += informacion => lookInput = Vector2.zero;
    }

    void OnEnable()
    {
        controls.Enable();
    }

    void OnDisable()
    {
        controls.Disable();
    }

    void Update()
    {
        float mouseX = lookInput.x * sensibilidad * Time.deltaTime;
        
        rotY += mouseX;

        transform.localRotation = Quaternion.Euler(0f, rotY, 0f);
    }
}
