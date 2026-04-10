using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{


    public GameObject enemyPrefab;
    public float spawnInterval = 2.0f;

    private bool isSpawning = false;
    private List<GameObject> activeEnemies = new List<GameObject>();
    private Coroutine spawnCoroutine;

    public void ToggleSpawner()
    {
        isSpawning = !isSpawning;

        if (isSpawning)
        {
            spawnCoroutine = StartCoroutine(SpawnRoutine());
        }
        else
        {
            StopCoroutine(spawnCoroutine);
            ClearEnemies();
        }
    }

    IEnumerator SpawnRoutine()
    {
        while (isSpawning)
        {
            GameObject newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            activeEnemies.Add(newEnemy);
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void ClearEnemies()
    {
        foreach (GameObject enemy in activeEnemies)
        {
            if (enemy != null) Destroy(enemy);
        }
        activeEnemies.Clear();
    }
}
