using UnityEngine;

public interface Estados
{
    void Entrar(CentralMachine cerebro);
    void Ejecutar(CentralMachine cerebro);
    void Salir(CentralMachine cerebro);
}


