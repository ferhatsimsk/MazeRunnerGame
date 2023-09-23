using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public Slider healthSlider; // Health bar Slider bileþeni

    public Level2CoinCol level2CoinCol; //CoinCollector scriptini kullanabilmek için

    private void Start()
    {
        level2CoinCol = FindObjectOfType<Level2CoinCol>();
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ghost"))
        {
            Destroy(collision.gameObject);
            TakeDamage(10);
        }
    }

    private void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            level2CoinCol.LoseGame();
        }
    }

    //private void LoseGame()
    //{
    //    Debug.Log("Game Over");
    //}

    private void UpdateHealthBar()
    {
        healthSlider.value = (float)currentHealth / maxHealth; // Saðlýk deðerini slider'ý güncelle
    }
}
