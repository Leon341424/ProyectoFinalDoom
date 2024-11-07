using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimientoaleatorio : MonoBehaviour
{
    public float speed = 2f;
    public float changeDirectionTime = 3f; // Tiempo para cambiar de dirección
    private Vector3 randomDirection;
    private float timer;

    // Variables para definir los límites de movimiento
    public float minX = -10f;
    public float maxX = 10f;
    public float minZ = -10f;
    public float maxZ = 10f;

    void Start()
    {
        ChangeDirection();
    }

    void Update()
    {
        // Mover al enemigo en la dirección aleatoria
        transform.position += randomDirection * speed * Time.deltaTime;

        // Restringir la posición del enemigo dentro de los límites
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, minX, maxX),
            transform.position.y, // Mantener la misma altura
            Mathf.Clamp(transform.position.z, minZ, maxZ)
        );

        // Actualizar el temporizador
        timer += Time.deltaTime;
        if (timer >= changeDirectionTime)
        {
            ChangeDirection();
        }
    }

    void ChangeDirection()
    {
        // Cambiar a una nueva dirección aleatoria
        randomDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
        timer = 0;
    }
}
