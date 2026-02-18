using UnityEngine;

public class VIEW : MonoBehaviour
{
     public float sensibilidad = 200f;

    private ControllersGame controls;
    private Vector2 lookInput;

   

    float rotY = 0f;

    void Awake()
    {
        controls = new ControllersGame();

        controls.PlayerControllers.VIEW.performed += ctx => lookInput = ctx.ReadValue<Vector2>();
        controls.PlayerControllers.VIEW.canceled += ctx => lookInput = Vector2.zero;
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
