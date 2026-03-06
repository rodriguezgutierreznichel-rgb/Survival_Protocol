using UnityEngine;
using UnityEngine.SceneManagement;

public class Botones : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IniciarJuego()
    {
        SceneManager.LoadScene("CINEMATICA");
    }

    public void CerrarJuego()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
