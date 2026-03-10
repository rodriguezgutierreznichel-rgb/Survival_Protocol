using UnityEngine;

public class InputController : MonoBehaviour
{
    public Vector2 MoverInput()
    {
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");

        return new Vector2(x, y);
    }

    
}
