using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map 
{
    public List<MapNode> mapNodes;

    public List<Vector2> path;

    public Map(List<MapNode> mapNodes, List<Vector2> path)
    {
        this.mapNodes = mapNodes;
        this.path = path;
    }
}
