using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musica : MonoBehaviour
{
    public AudioSource fondo;

    public void EmpiezaMusica()
    {
        if (!fondo.enabled)
        {
            fondo.enabled = true;
        }
        if (fondo != null)
        {
            fondo.Play();
        }    
    }

   
}
