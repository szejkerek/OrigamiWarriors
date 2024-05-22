using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : IDisplayable
{
    public string IconGUID { get; }
    public string DisplayName { get; }
    public GameObject characterGameObject { get; }
    public List<Stat> stats { get; }

    public Character(CharacterSO data) : this (data.Icon.AssetGUID, data.DisplayName, data.CharacterGameObject, stats: null)  
    {
        stats = CreateStats(data.Stats);
    }

    public Character(string iconGUID, string displayName, GameObject characterGameObject, List<Stat> stats)
    {
        this.IconGUID = iconGUID;
        this.DisplayName = displayName;
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
