using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoenemigos : MonoBehaviour
{
    public Transform player; // La posición del jugador
    public float speed = 2f; // Velocidad de movimiento

    void Update()
    {
        if (player != null)
        {
            // Calcular la dirección hacia el jugador
            Vector3 direction = (player.position - transform.position).normalized;
            // Mover al enemigo en esa dirección
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}
