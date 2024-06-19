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
    [SerializeField] List<Transform> spawnPoints;
    [SerializeField] List<EnemyChance> enemyPrefabs;
    [SerializeField] int maxEnemies;

    private void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
    }

    private IEnumerator SpawnEnemyRoutine()
    {
        while (true)
        {
            float waitTime = Random.Range(5f, 10f);
            yield return new WaitForSeconds(waitTime);

            int spawnIndex = Random.Range(0, spawnPoints.Count);
            Transform spawnPoint = spawnPoints[spawnIndex];
            if(ActiveEnemyCount() < maxEnemies)
            {
                Instantiate(PickEnemy(), spawnPoint.position, spawnPoint.rotation);
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
        List<EnemyChance> enemies = new List<EnemyChance>();
        foreach (var item in enemyPrefabs)
        {
            if(Random.Range(0f,1f) <= item.chanceToSpawn)
            {
                enemies.Add(item);
            }
        }

        return enemies.SelectRandomElement().EnemyPrefab;
    }
}
