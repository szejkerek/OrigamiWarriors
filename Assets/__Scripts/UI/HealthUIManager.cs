using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class HealthUIManager : MonoBehaviour
{
    [SerializeField] GameObject healthBarPrefab;
    [SerializeField] Canvas canvas;
    float yOffset = 70f;
    // Start is called before the first frame update
    void Start()
    {
        

        SpawnHealthBar( SavableDataManager.Instance.data.team.General,0);

        for (int i = 1;i <= SavableDataManager.Instance.data.team.TeamMembers.Count; i++)
        {
            SpawnHealthBar(SavableDataManager.Instance.data.team.TeamMembers[i-1], i);
        }
    }

    void SpawnHealthBar(Character character,int position)
    {
        RectTransform canvasRect = canvas.GetComponent<RectTransform>();
        Vector3 startPosition = new Vector3(canvasRect.rect.xMin + 170, canvasRect.rect.yMax -60, 0);


        Vector3 spawnPosition = startPosition - new Vector3(0, yOffset * position, 0);

        
        GameObject spawnedPrefab = Instantiate(healthBarPrefab, spawnPosition, Quaternion.identity, canvas.transform);
        spawnedPrefab.GetComponent<HealthBar>().Init(character);

        RectTransform spawnedRect = spawnedPrefab.GetComponent<RectTransform>();
        if (spawnedRect != null)
        {
            spawnedRect.anchoredPosition = new Vector2(startPosition.x , startPosition.y - yOffset * position);
        }
    }
}
