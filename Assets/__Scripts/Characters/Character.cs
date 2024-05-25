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

    public Item weapon;
    public Item armor;
    public Item skill;

    CharacterSO characterData;
    string characterGuid;

    public Character(string characterGuid)
    {
        this.characterGuid = characterGuid;
        characterData = new AssetReferenceItemSO(characterGuid).LoadAssetAsync<CharacterSO>().WaitForCompletion();

        this.IconGUID = characterData.Icon.AssetGUID;
        this.DisplayName = characterData.DisplayName;
        this.characterGameObject = characterData.CharacterGameObject;
        this.weapon = new Item(characterData.Weapon.AssetGUID);
        this.armor = new Item(characterData.Armor.AssetGUID);
        this.skill = new Item(characterData.Skill.AssetGUID);
        this.BaseStats = characterData.BaseStats;
 

    }
    
    public CharacterStats GetStats()
    {
        return BaseStats + weapon.GetStats() + armor.GetStats() + skill.GetStats();
    }
 
}