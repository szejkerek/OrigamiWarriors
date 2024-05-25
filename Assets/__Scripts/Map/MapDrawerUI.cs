using GordonEssentials;
using UnityEngine;
using Unity.Mathematics;
using System.Collections.Generic;
using UnityEngine.UI;

public class MapDrawerUI : Singleton<MapDrawerUI>
{
    public Map Map { get; protected set; }
    public GameObject contentParent;
    public GameObject nodePrefab;
    public GameObject linePrefab;
    public RectTransform rectTransform;
    private float contentX, contentY;

    public void Start()
    {
        
    }
    // Start is called before the first frame update
    public void ShowMapLayer(Map m , MapConfigSO config)
    {
        contentX = rectTransform.rect.width;
        contentY = rectTransform.rect.height;
        if (m == null)
        {
            Debug.LogWarning("Map was null in MapView.ShowMap()");
            return;
        }
        Dictionary<Point, GameObject> nodeObjects = new Dictionary<Point, GameObject>();



        foreach (MapNode mapNode in m.mapNodes)
        {

            var mapNodeObject = Instantiate(nodePrefab, contentParent.transform);
            mapNodeObject.transform.localPosition = CalculatePosition(mapNode.position);
            mapNode.position = mapNodeObject.transform.localPosition;
            Debug.Log("Map location: " + mapNode.locationOnMap + "Map position: " + mapNodeObject.transform.localPosition);
            nodeObjects[mapNode.locationOnMap] = mapNodeObject;

        }
        DrawConnections(m, nodeObjects);
        // Map = m;
    }

    private Vector2 CalculatePosition(Vector2 postitionNormalized)
    {
        float newX = math.remap(0f, 1f, -contentX * 3 / 8, +contentX * 3 / 8, postitionNormalized.x);
        float newY = math.remap(0f, 1f, -contentY * 3 / 8, +contentY * 3 / 8, postitionNormalized.y);


        return new Vector2(newX, newY);
    }

    private void DrawConnections(Map map, Dictionary<Point, GameObject> nodeObjects)
    {
        foreach (MapNode mapNode in map.mapNodes)
        {
            foreach (Point outNodeLocation in mapNode.outNodesLocations)
            {
                if (nodeObjects.TryGetValue(mapNode.locationOnMap, out GameObject fromNodeObject) &&
                    nodeObjects.TryGetValue(outNodeLocation, out GameObject toNodeObject))
                {
                    DrawLine(fromNodeObject.transform.localPosition, toNodeObject.transform.localPosition);
                }
            }
        }
    }

    private void DrawLine(Vector2 start, Vector2 end)
    {
        var lineObject = Instantiate(linePrefab, contentParent.transform);
        var lineRenderer = lineObject.GetComponent<UILine>();

        lineRenderer.SetPositions(start, end);
    }

}
