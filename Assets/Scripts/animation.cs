using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation : MonoBehaviour
{
    public float distance = 2f; 
    public float moveSpeed = 2f; 

    private Vector3 localOriginalPosition; 
    private bool isMoving = false;

    void Start()
    {
        localOriginalPosition = transform.localPosition;
    }

    public void OnButtonPress()
    {
        if (!isMoving)
        {
            StartCoroutine(MoveBackAndForth());
        }
    }

    IEnumerator MoveBackAndForth()
    {
        isMoving = true;

        
        Vector3 localTargetPosition = localOriginalPosition + new Vector3(0, 0, -distance);
        float elapsedTime = 0f;

        while (elapsedTime < 1f)
        {
            transform.localPosition = Vector3.Lerp(localOriginalPosition, localTargetPosition, elapsedTime);
            elapsedTime += Time.deltaTime * moveSpeed;
            yield return null;
        }

        transform.localPosition = localTargetPosition; 

        elapsedTime = 0f;
        while (elapsedTime < 1f)
        {
            transform.localPosition = Vector3.Lerp(localTargetPosition, localOriginalPosition, elapsedTime);
            elapsedTime += Time.deltaTime * moveSpeed;
            yield return null;
        }

        transform.localPosition = localOriginalPosition;

        isMoving = false;
    }
}
