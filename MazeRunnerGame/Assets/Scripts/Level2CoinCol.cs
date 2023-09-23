using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Level2CoinCol : MonoBehaviour
{
    private int collectedCoins = 0;
    private bool cubeActivated = false;
    private bool gameEnded = false;
    private float countdownTimer = 60f;

    public GameObject coinPrefab;
    public GameObject cube;
    public GameObject player;
    public NavMeshAgent enemyAgent;


    public TextMeshProUGUI countdownText;
    public TextMeshProUGUI resultText;
    public Button nextLevelButton;
    public Button restartButton;
    public Button mainMenuButton;

    public float enemySpeed = 3f;
    public int coinsNeededToActivateCube = 10;
    public int scoreThresholdForEnemyFollow = 3;

    private bool startEnemyFollow = false;

    private void Start()
    {
        enemyAgent = GameObject.FindGameObjectWithTag("Enemy").GetComponent<NavMeshAgent>();
        enemyAgent.speed = enemySpeed;



        countdownText.text = countdownTimer.ToString();
        resultText.gameObject.SetActive(false);
        nextLevelButton.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        mainMenuButton.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (gameEnded) return;

        countdownTimer -= Time.deltaTime;
        if (countdownTimer <= 0f)
        {
            gameEnded = true;
            LoseGame();
        }

        if (collectedCoins >= coinsNeededToActivateCube && !cubeActivated)
        {
            cubeActivated = true;
            cube.SetActive(true);
        }

        if (collectedCoins >= scoreThresholdForEnemyFollow && !startEnemyFollow)
        {
            startEnemyFollow = true;
            enemyAgent.enabled = true;
        }






        if (collectedCoins >= coinsNeededToActivateCube && cubeActivated && !gameEnded)
        {
            Vector3 cubePosition = cube.transform.position;
            float distanceToCube = Vector3.Distance(player.transform.position, cubePosition);
            if (distanceToCube <= 0.5f)
            {
                gameEnded = true;
                WinGame();
            }
        }

        if (startEnemyFollow)
        {
            enemyAgent.SetDestination(player.transform.position);
        }


        countdownText.text = Mathf.Round(countdownTimer).ToString();

        if (countdownTimer <= 0f && !gameEnded)
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
        }
        else if (other.CompareTag("Enemy"))
        {
            gameEnded = true;
            LoseGame();
        }
    }

    private void WinGame()
    {
        resultText.text = "Win";
        resultText.gameObject.SetActive(true);
        nextLevelButton.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(false);
        mainMenuButton.gameObject.SetActive(true);
       
        player.GetComponent<SimpleSampleCharacterControl>().enabled = false;
        //Time.timeScale = 0f;

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] ghosts = GameObject.FindGameObjectsWithTag("Ghost");

        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<BoxCollider>().enabled = false;
        }

        foreach (GameObject ghost in ghosts)
        {
            ghost.GetComponent<BoxCollider>().enabled = false;
        }
    }

    public void LoseGame()
    {
        resultText.text = "Lose";
        resultText.gameObject.SetActive(true);
        //nextLevelButton.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(true);
        mainMenuButton.gameObject.SetActive(true);

        player.GetComponent<SimpleSampleCharacterControl>().enabled = false;
    }
}
