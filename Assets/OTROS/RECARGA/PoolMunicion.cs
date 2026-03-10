using System.Collections.Generic;
using UnityEngine;

public class PoolMunicion : MonoBehaviour
{
    public static PoolMunicion instance;
    [SerializeField] GameObject cuboMunicionPrefab;
    [SerializeField] int cantidadInicial = 5;

    Stack<GameObject> poolMunicion = new Stack<GameObject>();

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);

        for (int i = 0; i < cantidadInicial; i++)
        {
            GameObject obj = Instantiate(cuboMunicionPrefab);
            obj.SetActive(false);
            poolMunicion.Push(obj);
        }
    }

    public void SoltarMunicion(Vector3 posicion)
    {
        GameObject bala;
        if (poolMunicion.Count > 0) bala = poolMunicion.Pop();
        else bala = Instantiate(cuboMunicionPrefab);

        bala.transform.position = posicion;
        bala.SetActive(true);
    }

    public void RegresarAlPool(GameObject obj)
    {
        obj.SetActive(false);
        poolMunicion.Push(obj);
    }
}
