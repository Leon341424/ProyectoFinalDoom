using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparo : MonoBehaviour
{
    public Camera playerCamera; 
    public float shootRange = 100f; 
    public int damage = 10; 
    public AudioSource shootAudio; 


    public void Shoot()
    {      
    if (!shootAudio.enabled)
        {
            shootAudio.enabled = true;
        }
    if (shootAudio != null)
    {
        shootAudio.Play();
        Debug.Log("Sonido de disparo reproducido");
    }
	Debug.Log("Disparo ejecutado!");
        Ray ray = playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;


        if (Physics.Raycast(ray, out hit, shootRange))
        {
            Debug.Log("Hit: " + hit.collider.name);

            EnemyHealth enemy = hit.collider.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }
}
