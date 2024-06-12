using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Character : IDisplayable , IHealth
{
    public Action OnHealthChange;
    public string DisplayIconGuid => IconGUID;
    public string DisplayName => Name;

    public string IconGUID;
    public string Name;
    public CharacterStats BaseStats;
    public int LostHealth;
    public SamuraiVisuals SamuraiVisuals;
    public GameObject CharacterPrefab;
    public Item Weapon;
    public Item Armor;
    public Item Skill;
    public string characterGuid;
    public List<string> passiveEffectsGuids = new List<string>(); //naprawiæ zapisywanie

    public List<PassiveEffect> PassiveEffects = new List<PassiveEffect>();
    public CharacterSO characterData;


    public Character(string characterGuid)
    {
        this.characterGuid = characterGuid;
        characterData = new AssetReferenceItemSO(characterGuid).LoadAssetAsync<CharacterSO>().WaitForCompletion();

        PassiveEffects = characterData.PassiveEffects;

        this.IconGUID = characterData.Icon.AssetGUID;
        this.Name = characterData.Name;
        this.CharacterPrefab = characterData.CharacterGameObject;
        Weapon = new Item(characterData.Weapon.AssetGUID);
        Armor = new Item(characterData.Armor.AssetGUID);
        Skill = new Item(characterData.Skill.AssetGUID);

        this.BaseStats = characterData.BaseStats;

        this.SamuraiVisuals = new SamuraiVisuals(characterData.SamuraiVisuals);
    }

    public CharacterStats GetStats()
    {
        CharacterStats stats = new CharacterStats();

        stats += Weapon.GetStats();
        stats += Armor.GetStats();
        stats += Skill.GetStats();

        return BaseStats + stats;
    }

    public void Damage(int valueHP)
    {
        LostHealth += valueHP;
        CharacterStats stats = GetStats();
        if (stats.Health <= LostHealth)
        {
            LostHealth = stats.Health;
            Debug.Log("I'm dead");
        }
        OnHealthChange?.Invoke();
    }

    public void Heal(int valueHP)
    {
        LostHealth -= valueHP;
        if (LostHealth < 0)
        {
            LostHealth = 0;
            Debug.Log("I'm full healed");
        }
        OnHealthChange?.Invoke();
    }

    public void HealToFull()
    {
        LostHealth = 0;
        OnHealthChange?.Invoke();
    }
}
