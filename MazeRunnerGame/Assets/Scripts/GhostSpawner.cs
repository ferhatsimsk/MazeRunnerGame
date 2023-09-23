using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostSpawner : MonoBehaviour
{
    public GameObject ghostPrefab; // Spawn edilecek ghostun prefab'ý
    public Transform target; // Ghostlarýn takip edeceði hedef

    public float spawnInterval = 2f; // Ghost spawn aralýðý (saniye)

    private bool isSpawning; // Spawn iþlemi devam ediyor mu?

    private void Start()
    {
        // Spawn iþlemini baþlat
        StartSpawning();
    }

    public void StartSpawning()
    {
        if (isSpawning)
        {
            return; // Spawn iþlemi zaten devam ediyorsa tekrar baþlatma
        }

        isSpawning = true;
        InvokeRepeating("SpawnGhost", spawnInterval, spawnInterval);
    }

    public void StopSpawning()
    {
        isSpawning = false;
        CancelInvoke("SpawnGhost");
    }

    private void SpawnGhost()
    {
        // Ghost prefabýndan yeni bir ghost oluþtur
        GameObject newGhost = Instantiate(ghostPrefab, transform.position, Quaternion.identity);

        // Oluþturulan ghostu player'ý takip etmek için yapýlandýr
        GhostMovement ghostMovement = newGhost.GetComponent<GhostMovement>();
        if (ghostMovement != null && target != null)
        {
            ghostMovement.SetTarget(target);
        }
    }
}




