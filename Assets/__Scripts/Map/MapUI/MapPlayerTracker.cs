using System;
using System.Collections.Generic;
using System.Linq;

public class MapPlayerTracker : Singleton<MapPlayerTracker>
{
    public Action<int> OnPopupChooose;
    public bool lockAfterSelecting = false;
    public MapManager mapManager;
    public MapDrawerUI view;
    public bool locked;

    private List<IDisplayable> choices = new List<IDisplayable>();
    private LevelResults actualLevelResuls = new LevelResults();

    public void Start()
    {
        OnPopupChooose += ApplyResult;
    }
    public void SendPlayerToNode(MapNodeUI mapNode)
    {
        if (locked) return;
        locked = lockAfterSelecting;
        mapManager.currentMap.path.Add(mapNode.mapNode.locationOnMap);
        //TODO: SAVE MAP
        SavableDataManager.Instance.data.map = mapManager.currentMap;
        SavableDataManager.Instance.Save();
        view.SetAttainableNodes();
        view.SetLineColors();

        choices.Clear();
        
        //RANDOM THINGS FOR
        IDisplayable a = SavableDataManager.Instance.data.team.General;
        IDisplayable b = SavableDataManager.Instance.data.team.TeamMembers[0];
        IDisplayable c = SavableDataManager.Instance.data.team.TeamMembers[1];
        choices = new List<IDisplayable> { a, b, c };

        switch (mapNode.mapNode.type)
        {
            case MapNodeType.Arena:
                SceneLoader.Instance.LoadScene(SceneConstants.Level_4);
                break;
            case MapNodeType.Armory:
                
                PopupController.Instance.PopupPanel.ShowAsCharacterChoose(choices, "Choose new ally", "opis", null, /*OnPopupChooose*/ null, null);

                break;
            case MapNodeType.Boss:
                break;
            case MapNodeType.Experience:
                break;
            case MapNodeType.Forge:

                //PopupController.Instance.PopupPanel.ShowAsEvent("EVENT uuuu", a, "DAWNO DAWNO TEM ZA LASAMI I GLAZAMI", null, null, null);

                break;
            case MapNodeType.Temple:
                break;
            case MapNodeType.WeaponReroll:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public void ApplyResult(int indexOfChoice)
    {
        //TYP rzeczy któr¹ dodajemy DO SPRAWDZENIA
        actualLevelResuls.newCharacters = new List<Character>() { choices[indexOfChoice] as Character };
        actualLevelResuls.Apply();
    }

    public void ApplyResult()
    {        
        actualLevelResuls.Apply();
    }
}
