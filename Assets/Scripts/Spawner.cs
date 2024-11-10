using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemies; 
    public int maxEnemiesVisible = 3; 
    public int totalEnemies = 10; 
    private int enemiesDefeated = 0; 
    private int currentEnemyIndex = 2; 
    public int indexInicio = 0;

    public void Inicio()
    {
        for (indexInicio = 0; indexInicio < maxEnemiesVisible && indexInicio < enemies.Length; indexInicio++)
        {
            enemies[indexInicio].SetActive(true); 
            EnemyHealth enemyHealth = enemies[indexInicio].GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.OnEnemyDefeated += OnEnemyDefeated; 
            }
        }
    }

    void Update()
    {
        if (enemiesDefeated >= totalEnemies)
        {
            Debug.Log("Todos los enemigos han sido derrotados.");
            indexInicio = 0;
            SceneManager.LoadScene("Victoria");
        }
    }

    public void OnEnemyDefeated()
    {
        enemiesDefeated++;

        Debug.Log("Enemigo derrotado. Total derrotados: " + enemiesDefeated);
        if (currentEnemyIndex < totalEnemies - 1)
        {
            currentEnemyIndex++;

            enemies[currentEnemyIndex].SetActive(true); 
            EnemyHealth enemyHealth = enemies[currentEnemyIndex].GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.OnEnemyDefeated += OnEnemyDefeated; 
            }
        }
    }
}