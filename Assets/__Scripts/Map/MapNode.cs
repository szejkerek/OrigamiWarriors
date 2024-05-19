using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MapNode
{
    public Vector2 position;
 
    public Vector2 locationOnMap;

    public List<Vector2> outNodesLocations = new List<Vector2>();

    public MapNodeType type;

    public MapNode(Vector2 locationOnMap, MapNodeType type)
    {
        this.locationOnMap = locationOnMap;
        this.type = type;
    }

    public void AddOutNode(Vector2 outNodesLocation)
    {
        if (outNodesLocations.Any(element => element.Equals(outNodesLocation)))
            return;

        outNodesLocations.Add(outNodesLocation);
    }
}
