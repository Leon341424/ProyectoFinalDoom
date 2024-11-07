using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seguircamara : MonoBehaviour
{
    public Transform cameraTransform; // Asigna aquí el Transform de la AR Camera
    public float followSpeed = 2f; // Velocidad de seguimiento

    void Update()
    {
        // Actualizar la posición del objeto para seguir a la cámara
        Vector3 targetPosition = cameraTransform.position;
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
    }
}
