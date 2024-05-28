using GordonEssentials.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public int configIndex;
    public List<MapConfigSO> allMapConfigs;
    public MapDrawerUI mapUI;
    public Map currentMap { get; private set; }

    private void Start()
    {
        currentMap = SaveManager<Map>.Load(allMapConfigs[configIndex].name + ".json");
        
        if (currentMap.mapNodes == null)
        {
            GenerateNewMap();
        }
        else
        {
            mapUI.ShowMap(currentMap, allMapConfigs[configIndex]);
        }

    }

    public void GenerateNewMap()
    {
        currentMap = MapGenerator.CreateMap(allMapConfigs[configIndex]);
        mapUI.ShowMap(currentMap, allMapConfigs[configIndex]);
        currentMap.Save();
    }


}
