using GordonEssentials;


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
        view.SetAttainableNodes();
        view.SetLineColors();

        //TODO ADD Delay, ANIMATION
        mapNode.LoadNodeLevel();
    }

}
