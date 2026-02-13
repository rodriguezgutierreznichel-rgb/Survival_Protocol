using UnityEngine;
using UnityEngine.Rendering;

public class EstadoPatrulla : Estados
{
    private int posicionAntigua;
    private int nuevaPosicion;

    public void Entrar(CentralMachine cerebro)
    {
        cerebro.agent.isStopped = false;
        cerebro.persiguiendo = false;
        cerebro.animator.SetBool("RUN", false);
        cerebro.animator.SetBool("ATTACK", false);
        NewPosition(cerebro);
        
    }

    public void Ejecutar(CentralMachine cerebro)
    {
        cerebro.animator.SetFloat("WALKING", cerebro.agent.velocity.magnitude);

        // Si llegamos al destino
        if (!cerebro.agent.pathPending && cerebro.agent.remainingDistance <= cerebro.agent.stoppingDistance)
        {
            // Guardamos el destino actual como antigua
            posicionAntigua = nuevaPosicion;

            // Elegimos un nuevo destino aleatorio distinto al anterior
            NewPosition(cerebro);
        }
    }

    public void Salir(CentralMachine cerebro)
    {

    }

    public void NewPosition(CentralMachine cerebro)
    {
        Debug.Log("Entro");
        nuevaPosicion = Random.Range(0, cerebro.posiciones.Length);
        cerebro.agent.SetDestination(cerebro.posiciones[nuevaPosicion].position);
        Debug.Log("esta en " + cerebro.posiciones[nuevaPosicion].position);
    }
}
