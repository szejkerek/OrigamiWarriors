using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MapLayer
{
    public int minOutGoing;

    public int maxOutGoing;

    public List<MapNodeTypeProbability> mapNodeTypesProbability;
}

[System.Serializable]
public class MapNodeTypeProbability
{
    public MapNodeType mapNodeType;
    [Range(0f, 1f)]
    public float probability;
}