using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MapLayer
{
    public int minOutGoing;

    public int maxOutGoing;

    public List<MapNodeTypeProbability> mapNodeTypesProbability;

    public MapNodeType DrawRandomNodeType()
    {
        float totalProbability = 0;
        foreach (var nodeTypeProbability in mapNodeTypesProbability)
        {
            totalProbability += nodeTypeProbability.probability;
        }

        float randomValue = Random.Range(0f, totalProbability);
        float cumulativeProbability = 0f;

        foreach (var nodeTypeProbability in mapNodeTypesProbability)
        {
            cumulativeProbability += nodeTypeProbability.probability;
            if (randomValue <= cumulativeProbability)
            {
                return nodeTypeProbability.mapNodeType;
            }
        }

        // This should not be reached if probabilities are set correctly
        return MapNodeType.Boss;
    }

}

[System.Serializable]
public class MapNodeTypeProbability
{
    public MapNodeType mapNodeType;
    [Range(0f, 1f)]
    public float probability;
}