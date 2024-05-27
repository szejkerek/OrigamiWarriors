using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Character : IDisplayable
{
    public string IconGUID { get; }
    public string DisplayName { get; }
    public CharacterStats BaseStats { get; set; }
    public GameObject characterGameObject { get; }

    public List<Item> items = new List<Item>(3);

    CharacterSO characterData;
    string characterGuid;

    public Character(string characterGuid)
    {
        this.characterGuid = characterGuid;
        characterData = new AssetReferenceItemSO(characterGuid).LoadAssetAsync<CharacterSO>().WaitForCompletion();

        this.IconGUID = characterData.Icon.AssetGUID;
        this.DisplayName = characterData.DisplayName;
        this.characterGameObject = characterData.CharacterGameObject;
        this.items.Add( new Item(characterData.Weapon.AssetGUID));
        this.items.Add(new Item(characterData.Armor.AssetGUID));
        this.items.Add(new Item(characterData.Skill.AssetGUID));
        this.BaseStats = characterData.BaseStats;
 

    }
    
    public CharacterStats GetStats()
    {
        CharacterStats stats = new CharacterStats();
        foreach(Item item in items)
        {
            stats += item.GetStats();
        }
        return BaseStats + stats;
    }
     
}
