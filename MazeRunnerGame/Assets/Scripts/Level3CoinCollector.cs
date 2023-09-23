using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Level3CoinCollector : MonoBehaviour
{
    public float Coin;
    public TextMeshProUGUI coinCountText;

    public GhostSpawner ghostSpawner; // Ghost Spawner referansý
    public int targetScore = 7; // Hedeflenen score miktarý

    public int currentScore = 0; // Mevcut score miktarý
    private bool ghostSpawned = false; // Ghost Spawner'ýn spawn edilip edilmediðini kontrol etmek için

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            CollectCoin(other.gameObject);
        }
    }

    private void CollectCoin(GameObject coin)
    {
        Destroy(coin); // Coin'i yok et

        currentScore++; // Score'u artýr

        coinCountText.text = "SCORE : " + currentScore.ToString();




        if (currentScore == targetScore && !ghostSpawned)
        {
            ghostSpawned = true;
            ghostSpawner.StartSpawning(); // Ghost Spawner'ý etkinleþtir
        }
    }
}
