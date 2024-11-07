using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soniDisparo : MonoBehaviour
{
    public AudioSource audioSource; // El AudioSource asignado en el Inspector
    public AudioClip shootClip;     // El clip de sonido para el disparo

    void Start()
    {
        // Asegúrate de que el AudioSource esté asignado y desactivado al inicio
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
        
        if (audioSource != null)
        {
            audioSource.enabled = true; // Dejamos el AudioSource activo, pero solo se reproducirá cuando sea necesario
        }
    }

    public void PlayShootSound()
    {
        if (audioSource != null && shootClip != null)
        {
            audioSource.PlayOneShot(shootClip);
        }
    }
}
