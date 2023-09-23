using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinCol : MonoBehaviour
{
    private int collectedCoins = 0;
    private bool cubeActivated = false;
    private bool gameEnded = false;
    private float countdownTimer = 60f;

    public GameObject coinPrefab;
    public GameObject cube;
    public GameObject player;
    public TextMeshProUGUI endText;
    public TextMeshProUGUI timerText;
    public GameObject nextLevelButton;
    public GameObject restartButton;
    public GameObject mainMenuButton;

    private void Update()
    {
        if (gameEnded) return;

        countdownTimer -= Time.deltaTime;
        timerText.text = Mathf.Round(countdownTimer).ToString();

        if (countdownTimer <= 0f)
        {
            gameEnded = true;
            LoseGame();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            collectedCoins++;

            if (collectedCoins >= 16 && !cubeActivated)
            {
                cubeActivated = true;
                cube.SetActive(true);
            }
        }
        else if (other.CompareTag("Finish") && !gameEnded)
        {
            gameEnded = true;
            WinGame();
        }
    }

    private void WinGame()
    {
        endText.text = "Win";
        endText.gameObject.SetActive(true);
        nextLevelButton.SetActive(true);
        mainMenuButton.SetActive(true);

        player.GetComponent<SimpleSampleCharacterControl>().enabled = false;
        //Time.timeScale = 0f;

    }

    private void LoseGame()
    {
        endText.text = "Lose";
        endText.gameObject.SetActive(true);
        restartButton.SetActive(true);
        mainMenuButton.SetActive(true);

        player.GetComponent<SimpleSampleCharacterControl>().enabled = false;
    }
}
