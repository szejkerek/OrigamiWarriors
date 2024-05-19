using GordonEssentials;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class MapDrawerUI : Singleton<MapDrawerUI>
{
    public Map Map { get; protected set; }
    public GameObject contentParent;
    public GameObject nodePrefab;

    private float contentX, contentY;

    public void Start()
    {
        RectTransform rectTransform = contentParent.GetComponent<RectTransform>();
        contentX = rectTransform.rect.width;
        contentY = rectTransform.rect.height;
    }
    // Start is called before the first frame update
    public void ShowMapLayer(Map m , MapConfigSO config)
    {
        if (m == null)
        {
            Debug.LogWarning("Map was null in MapView.ShowMap()");
            return;
        }

        foreach (MapNode mapNode in m.mapNodes)
        {
            //
            if(mapNode.position == Vector2.zero)
            {
                var mapNodeObject = Instantiate(nodePrefab, contentParent.transform);
                mapNodeObject.transform.localPosition = CalculatePosition(mapNode.locationOnMap, config.MapGridHeight, config.MapGridWidth);
                mapNode.position = mapNodeObject.transform.localPosition;
                Debug.Log("Map location: " + mapNode.locationOnMap + "Map position: " + mapNodeObject.transform.localPosition);
            }

        }

        Map = m;
    }

    private Vector2 CalculatePosition(Vector2 locationOnMap, int mapHeight, int mapWidth)
    {
        float offsetX = contentX / (mapWidth + 2);
        float newX = -(contentX / 2) + (locationOnMap.x + 1) * (contentX / mapWidth)  - offsetX;

        float offsetY = contentY / (mapHeight + 2);
        float newY = -(contentY / 2) + (locationOnMap.y + 1) * (contentY / mapHeight) - offsetY;

        return new Vector2(newX, newY);
    }
}
