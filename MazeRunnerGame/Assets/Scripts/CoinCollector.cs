using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCollector : MonoBehaviour
{
    public float Coin;
    public TextMeshProUGUI coinCountText;


    //public GhostSpawner ghostSpawner;
    //private int coinCount = 0;

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Coin")
    //    {
    //        Coin += 1;

    //        Destroy(other.gameObject);
    //        coinCountText.text = "SCORE : " + Coin.ToString();
    //    }

    //}

    //public void IncrementCoinCount()
    //{
    //    coinCount++;

    //    if (coinCount == 7)
    //    {
    //        ghostSpawner.enabled = true;
    //    }
    //}

    /*public GhostSpawner ghostSpawner;*/ // Ghost Spawner referans�
    /*public int targetScore = 7;*/ // Hedeflenen score miktar�

    public int currentScore = 0; // Mevcut score miktar�
    /*private bool ghostSpawned = false;*/ // Ghost Spawner'�n spawn edilip edilmedi�ini kontrol etmek i�in

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

        currentScore++; // Score'u art�r

        coinCountText.text = "SCORE : " + currentScore.ToString();




        //if (currentScore == targetScore && !ghostSpawned)
        //{
        //    ghostSpawned = true;
        //    ghostSpawner.StartSpawning(); // Ghost Spawner'� etkinle�tir
        //}
    }

}
