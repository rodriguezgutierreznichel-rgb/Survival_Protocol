using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class TraduccionVictoria : MonoBehaviour
{
    public TextMeshProUGUI botonReintentar, botonSalir, textVictoria;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        botonReintentar.text = LocalizationSettings.StringDatabase.GetLocalizedString("TEXTOS Y BOTONES", "-REINICIAR");
        botonSalir.text = LocalizationSettings.StringDatabase.GetLocalizedString("TEXTOS Y BOTONES", "-SALIR");
        textVictoria.text = LocalizationSettings.StringDatabase.GetLocalizedString("TEXTOS Y BOTONES", "-HAS GANADO");
    }
}
