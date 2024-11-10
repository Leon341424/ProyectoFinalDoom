using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimientoaleatorio : MonoBehaviour
{
    public Transform groundPlaneStage; // Arrastra aquí el Ground Plane Stage desde la jerarquía
    public float speed = 2f;
    public float changeDirectionTime = 3f; // Tiempo para cambiar de dirección
    private Vector3 randomDirection;
    private float timer;

    // Variables para definir los límites de movimiento relativos al Ground Plane Stage
    private Vector3 initialPosition;
    public float movementRangeX = 1f; // Rango de movimiento en X
    public float movementRangeZ = 1f; // Rango de movimiento en Z

    void Start()
    {
        if (groundPlaneStage == null)
        {
            Debug.LogError("Ground Plane Stage no está asignado. Por favor, arrástralo en el inspector.");
            return;
        }

        // Guardamos la posición inicial relativa al Ground Plane Stage
        initialPosition = groundPlaneStage.InverseTransformPoint(transform.position);
        ChangeDirection();
    }

    void Update()
    {
        // Mover al enemigo en la dirección aleatoria
        transform.position += randomDirection * speed * Time.deltaTime;

        // Convertir la posición actual del enemigo en coordenadas locales del Ground Plane Stage
        Vector3 localPosition = groundPlaneStage.InverseTransformPoint(transform.position);

        // Restringir el movimiento en X y Z en el rango establecido alrededor de la posición inicial
        localPosition.x = Mathf.Clamp(localPosition.x, initialPosition.x - movementRangeX, initialPosition.x + movementRangeX);
        localPosition.z = Mathf.Clamp(localPosition.z, initialPosition.z - movementRangeZ, initialPosition.z + movementRangeZ);

        // Convertir de nuevo a coordenadas globales del mundo
        transform.position = groundPlaneStage.TransformPoint(localPosition);

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
