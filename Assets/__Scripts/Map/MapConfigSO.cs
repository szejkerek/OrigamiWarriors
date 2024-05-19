using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewMapConfig", menuName = "Map/MapConfig")]
public class MapConfigSO : ScriptableObject
{   

    public int MapGridHeight;

    public int MapGridWidth;

    public List<MapNodeTypeSO> mapNodeTypes;
    
    public List<MapLayer> mapLayers;


}
