using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 
using TMPro;

public class municion : MonoBehaviour
{
    public int totalBullets = 30;
    public TextMeshProUGUI bulletText;

    void Start()
    {
        UpdateBulletUI();
    }

    public void ShootBullet()
    {
        if (totalBullets > 0)
        {
            totalBullets--;
            UpdateBulletUI();
            Debug.Log("Balas restantes: " + totalBullets);
            if (totalBullets <= 0)
            {
                GameOver();
            }
        }
    }

    public void UpdateBulletUI()
    {
        if (bulletText != null)
        {
            bulletText.text = totalBullets + "/30"; // Actualiza el texto en la UI
        }
    }

    public void GameOver()
    {
        Debug.Log("Sin balas. Game Over.");
        SceneManager.LoadScene("GameOver"); 
    }
}
