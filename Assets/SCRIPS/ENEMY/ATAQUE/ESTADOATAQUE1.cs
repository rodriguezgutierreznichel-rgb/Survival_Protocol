using UnityEngine;

public class ESTADOATAQUE1 : Estados
{
    public float tiempoDesapareciónEffect = 0.5f;

    public void Entrar(CentralMachine cerebro)
    {
        cerebro.agent.isStopped = true;
        cerebro.animator.SetBool("RUN", false);
        cerebro.animator.SetBool("ATTACK", true);

    }

    public void Ejecutar(CentralMachine cerebro)
    {
        cerebro.tiempo += Time.deltaTime;

        // Solo intentamos disparar cuando el cronómetro llega al límite
        if (cerebro.tiempo >= 2f)
        {
            Disparar(cerebro);
            cerebro.tiempo = 0; // REINICIAR el tiempo para que no dispare ráfagas infinitas
        }

    }

    public void Salir(CentralMachine cerebro)
    {
       
    }

    public void Disparar(CentralMachine cerebro)
    {
        // 1. Apuntar al jugador (Asegúrate de que 'cerebro' tenga la referencia al jugador)
        Vector3 direccionAlJugador = (cerebro.player.position - cerebro.puntoDeDisparo.position).normalized;
       

        // 2. Obtener la bala del Pool
        GameObject nuevaBala = CANPOOL1.instance.PopEnemigo();

        if (nuevaBala != null)
        {
            nuevaBala.transform.position = cerebro.puntoDeDisparo.position;
            nuevaBala.transform.forward = direccionAlJugador;
            nuevaBala.SetActive(true);

            Rigidbody rb = nuevaBala.GetComponent<Rigidbody>();

            // Limpiamos la velocidad previa por si el Pool nos da una bala con inercia
            rb.linearVelocity = Vector3.zero;

            
            rb.AddForce(direccionAlJugador * cerebro.fuerzaDeDisparo);

            // Efecto visual
            GameObject flash = Object.Instantiate(cerebro.efecto, cerebro.puntoDeDisparo.position, cerebro.puntoDeDisparo.rotation);
            Object.Destroy(flash, tiempoDesapareciónEffect);
        }
    }
}

