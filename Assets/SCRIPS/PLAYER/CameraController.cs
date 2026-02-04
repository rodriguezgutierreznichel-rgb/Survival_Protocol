using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float sensibilidadHorizontal = 0f;
    [SerializeField] float sensibilidadVertical = 0f;

    [SerializeField] Transform cameraAnchor = null;

    InputController inputController = null;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        inputController = GetComponent<InputController>();
    }

    // Update is called once per frame
    void Update()
    {
        MoverCamara();
    }

    void MoverCamara()
    {
        Vector2 input = inputController.MoverInput();

        transform.Rotate(Vector3.up * input.x * sensibilidadHorizontal * Time.deltaTime);

        cameraAnchor.Rotate(Vector3.right * input.y * sensibilidadVertical * Time.deltaTime);
    }

}
