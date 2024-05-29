using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Character : IDisplayable
{
    public string IconGUID { get; set; }
    public string DisplayName { get; set; }
    public CharacterStats BaseStats { get; set; }
    public GameObject CharacterPrefab { get; set; }

    public List<Item> Items = new List<Item>(3);

    CharacterSO characterData;
    string characterGuid;

    public Character(string characterGuid)
    {
        this.characterGuid = characterGuid;
        characterData = new AssetReferenceItemSO(characterGuid).LoadAssetAsync<CharacterSO>().WaitForCompletion();

        this.IconGUID = characterData.Icon.AssetGUID;
        this.DisplayName = characterData.DisplayName;
        this.CharacterPrefab = characterData.CharacterGameObject;
        this.Items.Add(new Item(characterData.Weapon.AssetGUID));
        this.Items.Add(new Item(characterData.Armor.AssetGUID));
        this.Items.Add(new Item(characterData.Skill.AssetGUID));
        this.BaseStats = characterData.BaseStats;


    }

    public CharacterStats GetStats()
    {
        CharacterStats stats = new CharacterStats();
        foreach(Item item in Items)
        {
            stats += item.GetStats();
        }
        return BaseStats + stats;
    }
     
}
