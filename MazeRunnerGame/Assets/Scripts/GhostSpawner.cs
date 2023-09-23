using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostSpawner : MonoBehaviour
{
    public GameObject ghostPrefab; // Spawn edilecek ghostun prefab'�
    public Transform target; // Ghostlar�n takip edece�i hedef

    public float spawnInterval = 2f; // Ghost spawn aral��� (saniye)

    private bool isSpawning; // Spawn i�lemi devam ediyor mu?

    private void Start()
    {
        // Spawn i�lemini ba�lat
        StartSpawning();
    }

    public void StartSpawning()
    {
        if (isSpawning)
        {
            return; // Spawn i�lemi zaten devam ediyorsa tekrar ba�latma
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
        // Ghost prefab�ndan yeni bir ghost olu�tur
        GameObject newGhost = Instantiate(ghostPrefab, transform.position, Quaternion.identity);

        // Olu�turulan ghostu player'� takip etmek i�in yap�land�r
        GhostMovement ghostMovement = newGhost.GetComponent<GhostMovement>();
        if (ghostMovement != null && target != null)
        {
            ghostMovement.SetTarget(target);
        }
    }
}




