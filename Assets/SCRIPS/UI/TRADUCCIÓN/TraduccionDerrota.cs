using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class TraduccionDerrota : MonoBehaviour
{
    public TextMeshProUGUI botonReintentar, botonSalir, textDerrota;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        botonReintentar.text = LocalizationSettings.StringDatabase.GetLocalizedString("TEXTOS Y BOTONES", "-REINICIAR");
        botonSalir.text = LocalizationSettings.StringDatabase.GetLocalizedString("TEXTOS Y BOTONES", "-SALIR");
        textDerrota.text = LocalizationSettings.StringDatabase.GetLocalizedString("TEXTOS Y BOTONES", "-HAS MUERTO");
    }
}
