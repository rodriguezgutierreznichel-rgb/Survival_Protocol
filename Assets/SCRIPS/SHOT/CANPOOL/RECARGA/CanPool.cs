using System.Collections.Generic;
using UnityEngine;

public class CanPool : MonoBehaviour
{
    public static CanPool instance;

    [SerializeField] GameObject balas;
    [SerializeField] GameObject balaEnemigo;
    public int maxElements;
    [SerializeField] int maxElementsEnemigo;

    [SerializeField] float tiempoRecargaEnemigo = 3f;
    

    public float temporizadorRecarga;

    Stack<GameObject> pool = new Stack<GameObject>();
    Stack<GameObject> poolEnemigo = new Stack<GameObject>();
    Stack<GameObject> poolItemsMunicion = new Stack<GameObject>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        for (int i = 0; i < maxElements; i++)
        {
            GameObject proyectil = Instantiate(balas);
            proyectil.SetActive(false);
            pool.Push(proyectil);
        }

        for (int i = 0; i < maxElementsEnemigo; i++)
        {
            GameObject proyectilEnemigo = Instantiate(balaEnemigo);
            proyectilEnemigo.SetActive(false);
            poolEnemigo.Push(proyectilEnemigo);
        }
    }

    // Update is called once per frame
    void Update()
    {
        CantidadVidas cantidad = GetComponent<CantidadVidas>();

        // Validamos que 'cantidad' no sea nulo antes de usarlo
        if (cantidad != null)
        {
            if (maxElementsEnemigo <= 0 && cantidad.vidas > 0 && gameObject.CompareTag("ENEMIGO"))
            {
                temporizadorRecarga += Time.deltaTime;

                if (temporizadorRecarga >= tiempoRecargaEnemigo)
                {
                    maxElementsEnemigo++;
                    temporizadorRecarga = 0;
                    Debug.Log("Enemigo recargó 1 bala");
                }
            }
            else if (cantidad.vidas <= 0 && gameObject.CompareTag("ENEMIGO"))
            {
                temporizadorRecarga = 0;
            }
        }
        else
        {
            // Esto te avisará en consola si falta el componente
            // Debug.LogWarning("No se encontró el componente CantidadVidas en " + gameObject.name);
        }
    }

    public GameObject PopObject()
    {
        if (maxElements <= 0)
        {
            
            Debug.Log("Balas insuficientes");
            return null;
        }

        maxElements--;

        GameObject objectToReturn = null;
        if (pool.Count != 0)
        {
            objectToReturn = pool.Pop();
        }
        else
        {
            objectToReturn = Instantiate(balas);
            objectToReturn.SetActive(false);
        }
        return objectToReturn;
    }

    public GameObject PopEnemigo()
    {
        GameObject objectToReturn = null;

        if (maxElementsEnemigo <= 0)
        {
            Debug.Log("Balas insuficientes");
            return null;
        }

        maxElementsEnemigo--;
       

        if (poolEnemigo.Count != 0)
        {
            objectToReturn = poolEnemigo.Pop();
        }
        else
        {
            objectToReturn = Instantiate(balaEnemigo);
            objectToReturn.SetActive(false);
        }

        return objectToReturn;
    }

    public void PushObject(GameObject obj)
    {
        obj.SetActive(false);
        pool.Push(obj);
    }

    public void PushEnemigo(GameObject obj)
    {
        obj.SetActive(false);
        poolEnemigo.Push(obj);
    }


    public void Recargar(int municion)
    {
        maxElements = maxElements + municion;
        Debug.Log("valas actuales " + maxElements);

    }
    public void PushItemMunicion(GameObject obj)
    {
        obj.SetActive(false);
        poolItemsMunicion.Push(obj); // Se guarda en su propia lista
    }


}

