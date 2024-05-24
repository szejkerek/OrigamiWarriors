using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : IDisplayable
{
    public string IconGUID { get; }
    public string DisplayName { get; }
    public CharacterStats Stats { get; }
    public GameObject characterGameObject { get; }
    public List<UpgradableStat> upgradableStats { get; }

    CharacterSO characterData;
    string characterGuid;

    public Character(string characterGuid)
    {
        this.characterGuid = characterGuid;
        characterData = new AssetReferenceItemSO(characterGuid).LoadAssetAsync<CharacterSO>().WaitForCompletion();

        this.IconGUID = characterData.Icon.AssetGUID;
        this.DisplayName = characterData.DisplayName;
        this.characterGameObject = characterData.CharacterGameObject;
        this.upgradableStats = characterData.CreateStats();
    }    
}

[System.Serializable]
public class CharacterStats
{
    public int Damage;
    public int Health;
    public int Speed;
}