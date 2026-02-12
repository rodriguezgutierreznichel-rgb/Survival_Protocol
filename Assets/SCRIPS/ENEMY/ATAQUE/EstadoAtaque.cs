using UnityEngine;

public class EstadoAtaque : Estados
{
    public void Entrar(CentralMachine cerebro)
    {
        cerebro.agent.isStopped = true;
        cerebro.animator.SetBool("RUN", false);
        cerebro.animator.SetBool("ATTACK", true);
        cerebro.animator.SetBool("WALKING", false);



        if (cerebro.tiempoDisponible >= cerebro.tiempoDeDisparo)
        {
            cerebro.tiempoDisponible = 0;
            GameObject nuevaBala = Object.Instantiate(cerebro.bala, cerebro.puntoDeDisparo.position, cerebro.puntoDeDisparo.rotation);
            Rigidbody rb = nuevaBala.GetComponent<Rigidbody>();

            Vector3 direccion = cerebro.puntoDeDisparo.forward;

            // 50% de probabilidad
            if (Random.value > cerebro.probabilidadDeAcierto)
            {
                // Falla: desviamos el disparo
                direccion += new Vector3(1f, 0f, 0f);
            }

            rb.AddForce(direccion.normalized * cerebro.fuerzaDeDisparo, ForceMode.Impulse);
        }
    }

    public void Ejecutar(CentralMachine cerebro)
    {

    }

    public void Salir(CentralMachine cerebro)
    {

    }

   
}
