using System.Collections.Generic;
using UnityEngine;

public class GameplayTeamManagement : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    [SerializeField] float spawnRadius;
    int maxAttempts = 100;
    float minDistanceBetween;
    List<Vector3> spawnPoints = new List<Vector3>();

    public Team team;

    private void Awake()
    {
        team = SavableDataManager.Instance.data.team;
        if (spawnPoint == null) Debug.LogWarning("Set spawn point of the level!");
        minDistanceBetween = spawnRadius/4;
        SpawnTeam();
    }

    private void SpawnTeam()
    {
        SpawnCharacter(team.General, Vector3.zero);

        foreach (Character objectToSpawn in team.TeamMembers)
        {
            int attempts = 0;
            bool spawned = false;

            while (!spawned && attempts < maxAttempts)
            {
                Vector3 newSpawnPoint = GetRandomPointInCircle(spawnPoint.position, spawnRadius);

                if (IsFarEnoughFromOthers(newSpawnPoint))
                {
                    SpawnCharacter(objectToSpawn, newSpawnPoint);
                    spawned = true;
                }

                attempts++;
            }

            if (!spawned)
            {
                Debug.LogWarning($"Could not place {objectToSpawn.CharacterPrefab.name} with the required minimum distance.");
                SpawnCharacter(objectToSpawn, Vector3.zero);
            }

        }
    }

    private void SpawnCharacter(Character objectToSpawn, Vector3 offsetFromSpawnPoint)
    {
        Vector3 spawnPosition = (offsetFromSpawnPoint.With(y: 0) + spawnPoint.position);
        spawnPoints.Add(spawnPosition);
        var spawned = Instantiate(objectToSpawn.CharacterPrefab, spawnPosition, Quaternion.identity);
        if(spawned.TryGetComponent(out Samurai samurai))
        {
            samurai.SetCharacterData(objectToSpawn);  
        }
        else
        {
            Debug.LogWarning("Could not assign Character data to samurai");
        }
    }

    Vector3 GetRandomPointInCircle(Vector3 center, float radius)
    {
        Vector2 randomPoint = Random.insideUnitCircle * radius;
        return new Vector3(center.x + randomPoint.x, center.y, center.z + randomPoint.y);
    }

    bool IsFarEnoughFromOthers(Vector3 point)
    {
        foreach (Vector3 spawnPoint in spawnPoints)
        {
            if (Vector3.Distance(spawnPoint, point) < minDistanceBetween)
            {
                return false;
            }
        }
        return true;
    }

    private void OnDrawGizmos()
    {
        if (spawnPoint != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(spawnPoint.position, spawnRadius);

            Gizmos.color = Color.red;
            foreach (Vector3 point in spawnPoints)
            {
                Gizmos.DrawSphere(point, 0.05f);
            }
        }
    }
}
