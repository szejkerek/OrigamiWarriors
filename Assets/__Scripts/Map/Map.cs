using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map 
{
    public List<MapNode> mapNodes;

    public List<Point> path;

    public Map(List<MapNode> mapNodes, List<Point> path)
    {
        this.mapNodes = mapNodes;
        this.path = path;
    }
}
