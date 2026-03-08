using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class InicioTraduccion : MonoBehaviour
{
    public TextMeshProUGUI botonInicio, botonSalir;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        botonInicio.text = LocalizationSettings.StringDatabase.GetLocalizedString("TEXTOS Y BOTONES", "-EMPEZAR");
        botonSalir.text = LocalizationSettings.StringDatabase.GetLocalizedString("TEXTOS Y BOTONES", "-SALIR");
    }
}
