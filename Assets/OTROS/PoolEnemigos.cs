using System.Collections.Generic;
using UnityEngine;

public class PoolEnemigos : MonoBehaviour
{
    public static PoolEnemigos instance;

    Stack<GameObject> pool = new Stack<GameObject>();

    public float maxElement;


    public float tiempoMaximo;
    public float tiempoSpawn;


    [SerializeField] GameObject enemigos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        for (int i = 0; i < maxElement; i++)
        {
            GameObject enemigo = Instantiate(enemigos);
            enemigo.SetActive(false);
            pool.Push(enemigo);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (tiempoSpawn < tiempoMaximo)
        {
            tiempoSpawn = tiempoSpawn + Time.deltaTime;
        }
           
        
       
    }

    public GameObject popObjects()
    {
        if (tiempoSpawn <= tiempoMaximo)
        {
            Debug.Log("No hay");
            return null;
        }

        tiempoSpawn = 0;
        GameObject objectToReturn;

        if (pool.Count != 0)
        {
            objectToReturn = pool.Pop();
        }
        else
        {
            objectToReturn = Instantiate(enemigos);
            objectToReturn.SetActive(false);
        }


        return objectToReturn;
    }

    public void PushObject(GameObject obj)
    {
        obj.SetActive(false);
        pool.Push(obj);
    }
}
