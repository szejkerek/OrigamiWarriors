using System;

public class MapPlayerTracker : Singleton<MapPlayerTracker>
{
    public bool lockAfterSelecting = false;
    public MapManager mapManager;
    public MapDrawerUI view;
    public bool locked;
    public void SendPlayerToNode(MapNodeUI mapNode)
    {
        if (locked) return;
        locked = lockAfterSelecting;
        mapManager.currentMap.path.Add(mapNode.mapNode.locationOnMap);
        //TODO: SAVE MAP
        mapManager.currentMap.Save();
        view.SetAttainableNodes();
        view.SetLineColors();


        switch (mapNode.mapNode.type)
        {
            case MapNodeType.Arena:
                SceneLoader.Instance.LoadScene(SceneConstants.Level_4);
                break;
            case MapNodeType.Armory:
                break;
            case MapNodeType.Boss:
                break;
            case MapNodeType.Experience:
                break;
            case MapNodeType.Forge:
                break;
            case MapNodeType.Temple:
                break;
            case MapNodeType.WeaponReroll:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

}
