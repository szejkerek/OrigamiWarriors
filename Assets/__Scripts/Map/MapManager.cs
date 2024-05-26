using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public int configIndex;
    public List<MapConfigSO> allMapConfigs;
    public MapDrawerUI mapUI;
    public Map currentMap { get; private set; }

    private void Start()
    {
        if(currentMap == null)
        {
            currentMap = MapGenerator.CreateMap(allMapConfigs[configIndex]);
            mapUI.ShowMap(currentMap, allMapConfigs[configIndex]);

            //TODO: SAVE MAP
        }

    }


}
