using System.Collections.Generic;
using UnityEngine;

public class CANPOOL1 : MonoBehaviour
{
    public static CANPOOL1 instance;

    [SerializeField] GameObject balas;
    [SerializeField] GameObject balaEnemigo;
    [SerializeField] int maxElements;
    [SerializeField] int maxElementsEnemigo;

    public float tiempoRecargaEnemigo = 3f;
    [SerializeField] float tiempoRecargaPlayer = 3f;

    public float temporizadorRecargaPlayer;
    public float temporizadorRecargaEnemigo;

    Stack<GameObject> pool = new Stack<GameObject>();
    Stack<GameObject> poolEnemigo = new Stack<GameObject>();

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
        if (temporizadorRecargaEnemigo <= tiempoRecargaEnemigo)
        {
            temporizadorRecargaEnemigo += Time.deltaTime;
        }

        if (temporizadorRecargaPlayer <= tiempoRecargaPlayer)
        {
            temporizadorRecargaPlayer += Time.deltaTime;
        }

        if (temporizadorRecargaEnemigo >= tiempoRecargaEnemigo)
        {
           
            maxElementsEnemigo = 1;
        }
        if (temporizadorRecargaPlayer >= tiempoRecargaPlayer)
        {
            maxElements = 1;
           
        }
    }

    public GameObject PopObject()
    {
        if (temporizadorRecargaPlayer < tiempoRecargaPlayer)
        {
            Debug.Log("Aún no puedes disparar");
            return null;
        }

        temporizadorRecargaPlayer = 0f; // reinicia el tiempo

        GameObject objectToReturn;

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
        if (temporizadorRecargaEnemigo < tiempoRecargaEnemigo)
        {
            Debug.Log("Enemigo esperando para disparar");
            return null;
        }

        temporizadorRecargaEnemigo = 0f;

        GameObject objectToReturn;

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


   
}
