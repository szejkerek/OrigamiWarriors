using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MapNodeType
{
    Enemy,
    RestSite,
    Store,
    Boss,
    Mystery
}


[CreateAssetMenu(fileName = "NewMapNodeType", menuName = "Map/MapNodeType")]
public class MapNodeTypeSO : ScriptableObject
{
    [field: SerializeField] public Sprite Icon { private set; get; }
    [field: SerializeField] public MapNodeType MapNodeType { private set; get; }
}
