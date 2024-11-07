using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparo : MonoBehaviour
{
    public Camera playerCamera; // La cámara principal del jugador
    public float shootRange = 100f; // Distancia máxima de disparo
    public int damage = 10; // Daño que hace el arma
    public AudioSource shootAudio; // Asegúrate de asignar el AudioSource aquí


    // Este método se puede llamar desde el botón
    public void Shoot()
    {      
    if (!shootAudio.enabled)
        {
            shootAudio.enabled = true;
        }
    if (shootAudio != null)
    {
        shootAudio.Play(); // Reproducir el sonido asignado al AudioSource
        Debug.Log("Sonido de disparo reproducido");
    }
	Debug.Log("Disparo ejecutado!");
        // Lanza un raycast desde el centro de la cámara hacia adelante
        Ray ray = playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;


        if (Physics.Raycast(ray, out hit, shootRange))
        {
            Debug.Log("Hit: " + hit.collider.name);

            // Si golpea un enemigo, aplicarle daño
            EnemyHealth enemy = hit.collider.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }
}
