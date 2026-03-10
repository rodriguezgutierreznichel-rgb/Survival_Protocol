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

    bool estaRecargandoEnemigo = false;

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
        // 1. Si llega a 0, activamos el modo recarga
        if (maxElementsEnemigo <= 0)
        {
            estaRecargandoEnemigo = true;
        }

        // 2. Si está en modo recarga, ejecutamos el tiempo
        if (estaRecargandoEnemigo)
        {
            temporizadorRecarga += Time.deltaTime;

            if (temporizadorRecarga >= tiempoRecargaEnemigo)
            {
                maxElementsEnemigo++;
                temporizadorRecarga = 0;
                Debug.Log("Recargando... Ahora tiene: " + maxElementsEnemigo);

                // 3. Si ya llegó al máximo de 3, desactivamos la recarga
                if (maxElementsEnemigo >= 3)
                {
                    maxElementsEnemigo = 3; // Aseguramos que no pase de 3
                    estaRecargandoEnemigo = false;
                    Debug.Log("Recarga completa (3 balas)");
                }
            }
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
        // Solo dispara si NO está recargando y tiene balas
        if (maxElementsEnemigo > 0 && !estaRecargandoEnemigo)
        {
            maxElementsEnemigo--;

            if (poolEnemigo.Count != 0)
            {
                return poolEnemigo.Pop();
            }
            else
            {
                GameObject obj = Instantiate(balaEnemigo);
                obj.SetActive(false);
                return obj;
            }
        }

        Debug.Log("No puede disparar: o tiene 0 balas o está recargando");
        return null;
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

