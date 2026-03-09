using UnityEngine;

public class MusicaDeFondo : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip sonidoDeAmbiente;

    void Update()
    {
        SonidoDeAmbiente();
    }
    void SonidoDeAmbiente()
    {
        audioSource.PlayOneShot(sonidoDeAmbiente);
    }
}
