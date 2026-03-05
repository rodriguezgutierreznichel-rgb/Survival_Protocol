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
        cerebro.tiempo += Time.deltaTime;
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

       

        if (cerebro.tiempo >= 2)
        {
            nuevaBala.transform.position = cerebro.puntoDeDisparo.position;
            nuevaBala.transform.rotation = cerebro.puntoDeDisparo.rotation;
            nuevaBala.SetActive(true);


            Rigidbody rb = nuevaBala.GetComponent<Rigidbody>();

            Vector3 direccion = (cerebro.puntoDeDisparo.forward);

            rb.AddForce(direccion * cerebro.fuerzaDeDisparo);

            GameObject flash = Object.Instantiate(cerebro.efecto, cerebro.puntoDeDisparo.position, cerebro.puntoDeDisparo.rotation);
            Object.Destroy(flash, 0.5f);
            rb.AddForce(direccion.normalized * cerebro.fuerzaDeDisparo, ForceMode.Impulse);

        }


        
        
    }
}

