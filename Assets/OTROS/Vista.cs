using UnityEngine;

public class Vista : MonoBehaviour
{

    float ejeX;
    float ejeY;
    float ejeZ;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ejeY = Input.GetAxis("Mouse X") * 200 * Time.deltaTime;
        transform.Rotate(ejeX, ejeY, ejeZ);
        
    }
}
