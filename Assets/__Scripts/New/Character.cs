using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character 
{
    Sprite icon;
    string displayName;
    GameObject characterGameObject;
    List<Stat> stats;

    public Character(CharacterSO data)
    {
        icon = data.Icon;
        displayName = data.DisplayName;
        characterGameObject = data.CharacterGameObject;
        stats = CreateStats(data.Stats);
    }

    public Character(Sprite icon, string displayName, GameObject characterGameObject, List<Stat> stats)
    {
        this.icon = icon;
        this.displayName = displayName;
        this.characterGameObject = characterGameObject;
        this.stats = stats;
    }

    List<Stat> CreateStats(List<StatSO> stats)
    {
        List<Stat> statsList = new List<Stat>();
        foreach (StatSO stat in stats)
        {
            statsList.Add(new Stat(stat));
        }
        return statsList;
    }
}
