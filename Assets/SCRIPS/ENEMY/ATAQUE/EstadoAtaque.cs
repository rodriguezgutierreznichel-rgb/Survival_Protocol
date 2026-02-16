using UnityEngine;

public class EstadoAtaque : Estados
{
    public void Entrar(CentralMachine cerebro)
    {
        cerebro.agent.isStopped = true;
        cerebro.animator.SetBool("RUN", false);
        cerebro.animator.SetBool("ATTACK", true);
       
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
        GameObject nuevaBala = CanPool.instance.PopEnemigo();

        if (nuevaBala == null)
        {
            Debug.Log("No puedo disparar");
            return;
        }

        nuevaBala.transform.position = cerebro.puntoDeDisparo.position;
        nuevaBala.transform.rotation = cerebro.puntoDeDisparo.rotation;
        nuevaBala.SetActive(true);
        

        Rigidbody rb = nuevaBala.GetComponent<Rigidbody>();

        Vector3 direccion = (cerebro.player.position - cerebro.puntoDeDisparo.position).normalized;

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
