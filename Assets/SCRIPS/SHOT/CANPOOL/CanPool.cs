using System.Collections.Generic;
using UnityEngine;

public class CanPool : MonoBehaviour
{
    public static CanPool instance;

    [SerializeField] GameObject balas;
    [SerializeField] int maxElements;

    Stack<GameObject> pool = new Stack<GameObject>();

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
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public void PushObject(GameObject obj)
    {
        obj.SetActive(false);
        pool.Push(obj);
    }

    
    public void Recargar(int municion)
    {
        maxElements = maxElements + municion;
        Debug.Log("valas actuales " + maxElements);

    }
}

