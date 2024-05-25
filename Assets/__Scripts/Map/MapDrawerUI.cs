using GordonEssentials;
using UnityEngine;
using Unity.Mathematics;
public class MapDrawerUI : Singleton<MapDrawerUI>
{
    public Map Map { get; protected set; }
    public GameObject contentParent;
    public GameObject nodePrefab;
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

        foreach (MapNode mapNode in m.mapNodes)
        {

            var mapNodeObject = Instantiate(nodePrefab, contentParent.transform);
            mapNodeObject.transform.localPosition = CalculatePosition(mapNode.position);
            mapNode.position = mapNodeObject.transform.localPosition;
            Debug.Log("Map location: " + mapNode.locationOnMap + "Map position: " + mapNodeObject.transform.localPosition);


        }

       // Map = m;
    }

    private Vector2 CalculatePosition(Vector2 postitionNormalized)
    {
        float newX = math.remap(0f, 1f, -contentX *3/8, +contentX * 3 / 8, postitionNormalized.x);
        float newY = math.remap(0f, 1f, -contentY *3/8, +contentY *3/8, postitionNormalized.y);


        return new Vector2(newX, newY);
    }
}
