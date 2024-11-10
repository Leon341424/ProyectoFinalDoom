using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 50;
    public AudioSource damageSound;

    public delegate void EnemyDefeated();
    public event EnemyDefeated OnEnemyDefeated;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (!damageSound.enabled)
        {
            damageSound.enabled = true;
        }
        if (damageSound != null)
        {
            damageSound.Play();
            Debug.Log("Sonido de disparo reproducido");
        }
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("Enemigo destruido");
	Movimientoaleatorio movimiento = GetComponent<Movimientoaleatorio>();
    if (movimiento != null)
    {
        movimiento.enabled = false;
    }
    OnEnemyDefeated?.Invoke();
    
    gameObject.SetActive(false);
    }

    public void ResetEnemy()
    {
        health = 50;
        gameObject.SetActive(true);
    }
}
