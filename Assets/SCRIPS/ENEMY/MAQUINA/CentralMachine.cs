using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class CentralMachine : MonoBehaviour
{
    private Estados estadoActual;

   

    //Patrullar 
    public NavMeshAgent agent;
    public Transform[] posiciones;
    public float tiempoNewPosition;


    //Perseguir
    public bool persiguiendo = false;
    public Transform player;
    public GameObject vista;
    public float distancia;
    public GameObject enemigo;
   

    //Atacar
    public float tiempoDisponible = 5f;
    public float tiempoDeDisparo = 0f;
    public GameObject bala;
    public Transform puntoDeDisparo;
    public float fuerzaDeDisparo = 100f;
    public float distanciaDeAtaque = 5f;
    public float probabilidadDeAcierto = 0.5f;
    public float tiempo = 0f;


    //Animaciones
    public Animator animator;

    //Efecto de disparo
    public GameObject efecto;

    public void Start()
    {
        CambiarEstado(new EstadoPatrulla());
    }

    public void Update()
    {
        if (estadoActual != null)
        {
            estadoActual.Ejecutar(this);
        }
    }

    public void CambiarEstado(Estados nuevoEstado)
    {
        if (estadoActual != null)
        {
            estadoActual.Salir(this);
        }

        estadoActual = nuevoEstado;

        if (estadoActual != null)
        {
            estadoActual.Entrar(this);
        }
    }

    public void EstadoPatrullar()
    {
        CambiarEstado(new EstadoPatrulla());
    }

    public void EstadoPerseguir()
    {
        CambiarEstado(new EstadoPerseguir());
    }

    public void EstadoAtacar()
    {
        //CambiarEstado(new EstadoAtaque());
        CambiarEstado(new ESTADOATAQUE1());
    }
}