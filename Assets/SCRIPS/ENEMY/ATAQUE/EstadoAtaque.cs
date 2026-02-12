using UnityEngine;

public class EstadoAtaque : Estados
{
    public void Entrar(CentralMachine cerebro)
    {
        cerebro.agent.isStopped = true;
        cerebro.animator.SetBool("RUN", false);
        cerebro.animator.SetBool("ATTACK", true);
        cerebro.animator.SetBool("WALKING", false);
    }

    public void Ejecutar(CentralMachine cerebro)
    {
        if (cerebro.tiempoDisponible >= cerebro.tiempoDeDisparo)
        {
            cerebro.tiempoDisponible = 0;
            Disparar(cerebro);
        }
        if (cerebro.tiempoDisponible < cerebro.tiempoDeDisparo)
        {

            cerebro.tiempoDisponible += Time.deltaTime;

        }

    }

    public void Salir(CentralMachine cerebro)
    {

    }

    public void Disparar(CentralMachine cerebro)
    {
        GameObject nuevaBala = Object.Instantiate(cerebro.bala, cerebro.puntoDeDisparo.position, cerebro.puntoDeDisparo.rotation);
        Rigidbody rb = nuevaBala.GetComponent<Rigidbody>();

        Vector3 direccion = (cerebro.player.position - cerebro.puntoDeDisparo.position).normalized;

        // 50% de probabilidad
        if (Random.value > cerebro.probabilidadDeAcierto)
        {
            float desviacion = 0.8f; 

            direccion += new Vector3(
                Random.Range(-desviacion, desviacion),
                Random.Range(-desviacion, desviacion),
                Random.Range(-desviacion, desviacion)
            );
        }

        rb.AddForce(direccion.normalized * cerebro.fuerzaDeDisparo, ForceMode.Impulse);
    }
}
