using UnityEngine;
using UnityEngine.AI;

public class EstadoPerseguir : Estados
{
   


    public void Entrar(CentralMachine cerebro)
    {
        cerebro.agent.SetDestination(cerebro.player.position);

        cerebro.animator.SetBool("RUN", true);
        cerebro.animator.SetBool("WALKING", false);
    }

    public void Ejecutar(CentralMachine cerebro)
    {
       
    }

    public void Salir(CentralMachine cerebro)
    {
        cerebro.animator.SetBool("RUN", false);
        
    }
}
