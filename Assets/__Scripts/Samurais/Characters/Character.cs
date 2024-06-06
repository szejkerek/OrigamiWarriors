using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Character : IDisplayable
{
    public string DisplayIconGuid => IconGUID;
    public string DisplayName => Name;

    public string IconGUID;
    public string Name;
    public CharacterStats BaseStats;
    public SamuraiVisuals SamuraiVisuals;
    public GameObject CharacterPrefab;
    public List<Item> Items;
    public string characterGuid;

    CharacterSO characterData;

    public Character(string characterGuid)
    {
        Items = new List<Item>(3);

        this.characterGuid = characterGuid;
        characterData = new AssetReferenceItemSO(characterGuid).LoadAssetAsync<CharacterSO>().WaitForCompletion();

        this.IconGUID = characterData.Icon.AssetGUID;
        this.Name = characterData.Name;
        this.CharacterPrefab = characterData.CharacterGameObject;
        this.Items.Add(new Item(characterData.Weapon.AssetGUID));
        this.Items.Add(new Item(characterData.Armor.AssetGUID));
        this.Items.Add(new Item(characterData.Skill.AssetGUID));
        this.BaseStats = characterData.BaseStats;

        this.SamuraiVisuals = new SamuraiVisuals(characterData.SamuraiVisuals);
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
