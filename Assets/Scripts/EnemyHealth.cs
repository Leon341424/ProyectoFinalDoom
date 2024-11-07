using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 50;
    public AudioSource damageSound;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (!damageSound.enabled)
        {
            damageSound.enabled = true;
        }
        if (damageSound != null)
        {
            damageSound.Play(); // Reproducir el sonido asignado al AudioSource
            Debug.Log("Sonido de disparo reproducido");
        }
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemigo destruido");
	Movimientoaleatorio movimiento = GetComponent<Movimientoaleatorio>();
    if (movimiento != null)
    {
        movimiento.enabled = false;
    }

    // Destruye el objeto enemigo
    Destroy(gameObject);
    }
}
