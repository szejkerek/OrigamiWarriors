using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character 
{
    public Sprite icon { get; private set; }
    public string displayName { get; private set; }
    public GameObject characterGameObject { get; private set; }
    public List<Stat> stats { get; private set; }

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
