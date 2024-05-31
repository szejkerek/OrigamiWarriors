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

        IDisplayable a = SavableDataManager.Instance.data.team.General;
        switch (mapNode.mapNode.type)
        {
            case MapNodeType.Arena:
                SceneLoader.Instance.LoadScene(SceneConstants.Level_4);
                break;
            case MapNodeType.Armory:
                
                //PopupController.Instance.popup.gameObject.SetActive(true);

                //TODO tworzenie nowych Charakterów oraz obs³uga LevelResults z nowymi danymi które zdobyliœmy
                
                IDisplayable b = SavableDataManager.Instance.data.team.TeamMembers[0];
                IDisplayable c = SavableDataManager.Instance.data.team.TeamMembers[1];

                PopupController.Instance.popup.ShowAsCharacterChoose("Choose new ally", a, b, a, "opis", null, null, null);

                break;
            case MapNodeType.Boss:
                break;
            case MapNodeType.Experience:
                break;
            case MapNodeType.Forge:

                PopupController.Instance.popup.ShowAsEvent("EVENT uuuu", a, "DAWNO DAWNO TEM ZA LASAMI I GLAZAMI", null, null, null);

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
