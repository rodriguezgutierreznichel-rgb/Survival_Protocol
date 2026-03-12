using Unity.VisualScripting;
using UnityEngine;

public class EstadoHuir : Estados
{
    private float dejarDescanso = 0.3f;
    private float tiempoNecesario = 1f;
    public void Entrar(CentralMachine cerebro)
    {
        Debug.Log("Tengo que huir");
        
      
        DistanciaMasLarga(cerebro);

    }

    public void Ejecutar(CentralMachine cerebro)
    {
        if (!cerebro.agent.pathPending && cerebro.agent.remainingDistance < dejarDescanso)
        {
            cerebro.tiempoNewPosition += Time.deltaTime;
            Debug.Log("Llegamos al destino");

           

            if (cerebro.tiempoNewPosition >= tiempoNecesario)
            {
                cerebro.EstadoPatrullar();
                cerebro.tiempoNewPosition = 0;
            }

        }
    }

    public void Salir(CentralMachine cerebro)
    {
       
    }

    public void DistanciaMasLarga(CentralMachine cerebro)
    {
        for (int i = 0; i < 3; i++)
        {
            float distancia = Vector3.Distance(cerebro.enemigo.transform.position, cerebro.posiciones[i].transform.position);
            Debug.Log("la distancia es de " + cerebro.posiciones[i].name + distancia);
          
            cerebro.agent.SetDestination(cerebro.posiciones[1].position);
            

        }
    }
}
