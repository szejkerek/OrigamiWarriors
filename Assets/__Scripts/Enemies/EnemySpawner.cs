using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class EnemyChance
{
    public GameObject EnemyPrefab;
    [Range(0f,1f)] public float chanceToSpawn;
}

public class EnemySpawner : MonoBehaviour
{
    public static Action OnEnemySpawned;
    [SerializeField] List<Transform> spawnPoints;
    [SerializeField] List<EnemyChance> enemyPrefabs;

    int spawnedEnemies;

    public void Init(int maxEnemies, int atOnceLimit)
    {
        StartCoroutine(SpawnEnemyRoutine(maxEnemies, atOnceLimit));
    }

    private IEnumerator SpawnEnemyRoutine(int maxEnemies, int atOnceLimit)
    {
        while (true)
        {
            float waitTime = UnityEngine.Random.Range(5f, 10f);
            yield return new WaitForSeconds(waitTime);

            int spawnIndex = UnityEngine.Random.Range(0, spawnPoints.Count);
            Transform spawnPoint = spawnPoints[spawnIndex];
            if(ActiveEnemyCount() < atOnceLimit)
            {
                Instantiate(PickEnemy(), spawnPoint.position, spawnPoint.rotation);
                OnEnemySpawned?.Invoke();
                spawnedEnemies++;
                if(spawnedEnemies >= maxEnemies)
                {
                    break;
                }

            }
        }
    }

    int ActiveEnemyCount()
    {
        return FindObjectsOfType<Enemy>().ToList().Count(); 
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red; // Set the color of the Gizmos
        foreach (Transform spawnPoint in spawnPoints)
        {
            if (spawnPoint != null)
            {
                Gizmos.DrawSphere(spawnPoint.position, 1f);
            }
        }
    }

    GameObject PickEnemy()
    {
        List<EnemyChance> enemies = new();
        foreach (var item in enemyPrefabs)
        {
            if (UnityEngine.Random.Range(0f,1f) <= item.chanceToSpawn)
            {
                enemies.Add(item);
            }
        }

        return enemies.SelectRandomElement().EnemyPrefab;
    }
}
