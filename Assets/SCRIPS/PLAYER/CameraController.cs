using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float sensibilidadMouse = 0f;
    [SerializeField] float sensibilidadMouse2 = 0f;

    [SerializeField] Transform _cameraAnchor = null;

    InputController _inputController = null;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _inputController = GetComponent<InputController>();
    }

    // Update is called once per frame
    void Update()
    {
        MoverCamara();
    }

    void MoverCamara()
    {
        Vector2 input = _inputController.MouseInput();

        transform.Rotate(Vector3.up * input.x * sensibilidadMouse * Time.deltaTime);

        Vector3 angle = _cameraAnchor.eulerAngles;
        angle.x += input.y * sensibilidadMouse2 * Time.deltaTime;

        _cameraAnchor.eulerAngles = angle;
    }
}
