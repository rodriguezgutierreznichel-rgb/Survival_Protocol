using UnityEngine;

public class EstadoPatrulla : Estados
{ 
    public void Entrar(CentralMachine cerebro)
    {
        cerebro.animator.SetBool("RUN", false);
        cerebro.animator.SetBool("PIU PIU", false);
        Debug.Log("Te perdí");
        cerebro.persiguiendo = false;
        cerebro.agent.SetDestination(cerebro.posiciones[0].position);
        cerebro.animator.SetFloat("WALKING", cerebro.agent.velocity.magnitude);
    }

    public void Ejecutar(CentralMachine cerebro)
    {

    }

    public void Salir(CentralMachine cerebro)
    {

    }
}
