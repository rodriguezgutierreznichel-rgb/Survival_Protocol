using UnityEngine;

public class ESTADOATAQUE1 : Estados
{
    public void Entrar(CentralMachine cerebro)
    {
        cerebro.agent.isStopped = true;
        cerebro.animator.SetBool("RUN", false);
        cerebro.animator.SetBool("ATTACK", true);

    }

    public void Ejecutar(CentralMachine cerebro)
    {
        Disparar(cerebro);

    }

    public void Salir(CentralMachine cerebro)
    {

    }

    public void Disparar(CentralMachine cerebro)
    {
        GameObject nuevaBala = CANPOOL1.instance.PopEnemigo();

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
            Debug.Log("Falla");
            float desviacion = 5f;

            direccion.x += Random.Range(-desviacion, desviacion);


            direccion.y += Random.Range(-desviacion, desviacion);


            direccion.z += Random.Range(-desviacion, desviacion);
        }
        else
        {
            Debug.Log("Acierta");
        }

        rb.AddForce(direccion.normalized * cerebro.fuerzaDeDisparo, ForceMode.Impulse);
    }
}

