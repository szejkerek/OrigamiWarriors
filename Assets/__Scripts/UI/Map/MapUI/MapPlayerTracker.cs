using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
public class MapPlayerTracker : Singleton<MapPlayerTracker>
{
    public Action<int> OnPopupChooose;
    public bool lockAfterSelecting = false;
    public MapManager mapManager;
    public MapDrawerUI view;
    public bool locked;

    private List<IDisplayable> choices = new List<IDisplayable>();

    public void SendPlayerToNode(MapNodeUI mapNode)
    {
        if (locked)
        {
            return;
        }

        locked = lockAfterSelecting;
        mapManager.currentMap.path.Add(mapNode.mapNode.locationOnMap);
        //TODO: SAVE MAP
        SavableDataManager.Instance.data.map = mapManager.currentMap;
        SavableDataManager.Instance.Save();
        view.SetAttainableNodes();
        view.SetLineColors();

        choices.Clear();    
        IDisplayable a = SavableDataManager.Instance.data.team.General;
        IDisplayable b = SavableDataManager.Instance.data.team.TeamMembers[0];
        IDisplayable c = SavableDataManager.Instance.data.team.TeamMembers[1];
        choices = new List<IDisplayable> { a, b, c };

        switch (mapNode.mapNode.type)
        {
            case MapNodeType.Arena:
                SceneLoader.Instance.LoadScene(SceneConstants.Level_1);
                break;
            case MapNodeType.Armory:
                PopupController.Instance.PopupPanel.ChooseModal(choices, TryAddNewCharacter, "Choose new ally", "opis");
                break;
            case MapNodeType.Boss:
                break;
            case MapNodeType.Experience:
                break;
            case MapNodeType.Forge:
                PopupController.Instance.PopupPanel.ShowAsEvent("EVENT uuuu", new AssetReference(a.DisplayIconGuid).LoadAssetAsync<Sprite>().WaitForCompletion(), "DAWNO DAWNO TEM ZA LASAMI I GLAZAMI", null, null, null);
                break;
            case MapNodeType.Temple:
                break;
            case MapNodeType.WeaponReroll:
                break;
            default:
                throw new NotImplementedException();
        }
    }

    private void TryAddNewCharacter(IDisplayable displayable)
    {
        Character character = displayable as Character;
        if (character == null)
        {
            Debug.Log("Couldnt get Character from modal.");
            return;
        }
    }
}
