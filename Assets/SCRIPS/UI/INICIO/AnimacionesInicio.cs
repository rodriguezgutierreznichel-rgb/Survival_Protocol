using TMPro;
using UnityEngine;

public class AnimacionesInicio : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI tituloDelJuego;

    public GameObject botonEmpezar, botonSalir;

    [SerializeField] LeanTweenType curva;

    public float velocidadDeAnimacion = 0f;

    public Vector2 newPositionText = new Vector2(0, 0);
    public Vector2 newPositionButton = new Vector2(0, 0);

    Vector2 escalaOriginalDelTitulo;
    Vector2 escalaOriginalDelBotonEmpezar;
    Vector2 escalaOriginalDelBotonSalir;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        escalaOriginalDelTitulo = tituloDelJuego.rectTransform.localScale;
        escalaOriginalDelBotonEmpezar = botonEmpezar.transform.localScale;
        escalaOriginalDelBotonSalir = botonSalir.transform.localScale;

        Animacion();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void Animacion()
    {
        tituloDelJuego.rectTransform.localScale = escalaOriginalDelTitulo;
        botonEmpezar.transform.localScale = escalaOriginalDelBotonEmpezar;
        botonSalir.transform.localScale = escalaOriginalDelBotonSalir;

        LeanTween.scale(tituloDelJuego.rectTransform, newPositionText, velocidadDeAnimacion).setEase(curva);
        LeanTween.scale(botonEmpezar, newPositionButton, velocidadDeAnimacion).setEase(curva);
        LeanTween.scale(botonSalir, newPositionButton, velocidadDeAnimacion).setEase(curva);
    }
   
}
