using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public MapConfigSO config;
    public MapDrawerUI mapUI;
    public Map currentMap { get; private set; }

    private void Start()
    {
        currentMap = MapGenerator.CreateMap(config);
        mapUI.ShowMapLayer(currentMap, config);
        
    }

    public void DrawMap()
    {
        //Ograniczenie do max u¿yæ gdzieœ
        //currentMap.path.Add(currentMap.mapNodes[currentMap.mapNodes.Count - 1].locationOnMap);
        //MapGenerator.UpdateMap(currentMap, config);
        //mapUI.ShowMapLayer(currentMap, config);
    }

}
