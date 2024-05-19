
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using UnityEngine;

public static class MapGenerator
{
    private static MapConfigSO mapConfig;
    private static readonly List<List<MapNode>> mapNodes = new List<List<MapNode>>();

    public static Map CreateMap(MapConfigSO config)
    {
        if (config == null)
        {
            Debug.LogWarning("mapConfig was null");
            return null;
        }
        mapConfig = config;
        mapNodes.Clear();

        MapNode newNode = CreateFirstNode();

        List<MapNode> nodes = new List<MapNode>();
        nodes.Add(newNode);

        return new Map(nodes, new List<Vector2>());
    }

    private static MapNode CreateFirstNode()
    {
        int layer = 0;
        MapLayer mapLayer = mapConfig.mapLayers[layer];
        
        if (mapLayer == null)
        {
            Debug.LogWarning("mapConfig layer 0 was null");
            return null;
        }

        Vector2 location = new Vector2 (0, mapConfig.MapGridHeight / 2);

        return new MapNode(location, mapLayer.DrawRandomNodeType());
    }

    public static void UpdateMap(Map map, MapConfigSO config)
    {
        if (config == null)
        {
            Debug.LogWarning("mapConfig was null");
            return;
        }
        mapConfig = config;
        
        List<MapNode> newNodes = CreateNodesForLayer(map, map.path.Count);

        map.mapNodes.AddRange(newNodes);
    }



    private static List<MapNode> CreateNodesForLayer(Map map, int layer)
    {
        MapLayer mapLayer = mapConfig.mapLayers[layer];
        MapNode formNode = map.mapNodes.Where(n => n.position == map.path[layer - 1]).First();
        if (mapLayer == null)
        {
            Debug.LogWarning("mapConfig layer 0 was null");
            return null;
        }

        int numberOfNodes = Random.Range(0f, 1f) <= 0.5f ? mapLayer.minOutGoing : mapLayer.maxOutGoing;
        List<MapNode> mapNodes = new List<MapNode>();

        for (int i = 0; i < numberOfNodes; i++)
        {
            Vector2 location = new Vector2(layer,(i+1) * mapConfig.MapGridHeight / (numberOfNodes +2));
            mapNodes.Add(new MapNode(location, mapLayer.DrawRandomNodeType()));
            formNode.outNodesLocations.Add(location);
        }

        return mapNodes;
    }
}
