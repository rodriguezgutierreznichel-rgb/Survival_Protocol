using UnityEngine;
using UnityEngine.Rendering;

public class EstadoPatrulla : Estados
{
    //Posiciones y velocidad
    private int posicionAntigua;
    private int nuevaPosicion;
    public float velocidad;
    private float dejarDescanso = 0.3f;

    //Tiempo
    private float tiempoNecesario = 1f;

    public void Entrar(CentralMachine cerebro)
    {
        cerebro.agent.isStopped = false;
        cerebro.persiguiendo = false;
        cerebro.animator.SetBool("RUN", false);
        cerebro.animator.SetBool("ATTACK", false);
        cerebro.agent.speed = 2f;
        NewPosition(cerebro);
        
    }

    public void Ejecutar(CentralMachine cerebro)
    {
        cerebro.animator.SetFloat("WALKING", cerebro.agent.velocity.magnitude);

        // Si llegamos al destino
        if (!cerebro.agent.pathPending && cerebro.agent.remainingDistance < dejarDescanso)
        {
            cerebro.tiempoNewPosition += Time.deltaTime;
            Debug.Log("Llegamos al destino");

            posicionAntigua = nuevaPosicion;

            if (cerebro.tiempoNewPosition >= tiempoNecesario)
            {
                NewPosition(cerebro);
                cerebro.tiempoNewPosition = 0;
            }
           
        }
    }

    public void Salir(CentralMachine cerebro)
    {
        
    }

    public void NewPosition(CentralMachine cerebro)
    {
        //Debug.Log("Entro");
        int posicionAnterior = nuevaPosicion;

        // Mientras el nuevo índice sea igual al anterior, sigue buscando
        while (nuevaPosicion == posicionAnterior)
        {
            nuevaPosicion = Random.Range(0, cerebro.posiciones.Length);
        }

        cerebro.agent.SetDestination(cerebro.posiciones[nuevaPosicion].position);
        //Debug.Log("esta en " + cerebro.posiciones[nuevaPosicion].position);
    }
}
