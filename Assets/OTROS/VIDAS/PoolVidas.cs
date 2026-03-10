using System.Collections.Generic;
using UnityEngine;

public class PoolVidas : MonoBehaviour
{
    public static PoolVidas instance;
    [SerializeField] GameObject cuboVidaPrefab;
    [SerializeField] int cantidadInicial = 5;

    Stack<GameObject> poolVida = new Stack<GameObject>();

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);

        for (int i = 0; i < cantidadInicial; i++)
        {
            GameObject obj = Instantiate(cuboVidaPrefab);
            obj.SetActive(false);
            poolVida.Push(obj);
        }
    }

    public void SoltarVida(Vector3 posicion)
    {
        GameObject vida;
        if (poolVida.Count > 0) vida = poolVida.Pop();
        else vida = Instantiate(cuboVidaPrefab);

        vida.transform.position = posicion;
        vida.SetActive(true);
    }

    public void RegresarAlPool(GameObject obj)
    {
        obj.SetActive(false);
        poolVida.Push(obj);
    }
}
