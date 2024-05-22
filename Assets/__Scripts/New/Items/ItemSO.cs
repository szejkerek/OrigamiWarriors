using GordonEssentials.Types;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class Item : IDisplayable, IUpgradable
{
    public string IconGUID { get; }
    public string DisplayName { get; }
    public int MaxLevel { get; }
    public int Level { get; set; }
    public int Cost { get; }
    public ItemType itemType { get; private set; }
    public ClassType classType { get; private set; }
    public AdditionalItemInfo additionalItemInfo { get; private set; }


    public Item(string IconGUID, string displayName, int maxLevel, int level, ItemType itemType, ClassType classType, AdditionalItemInfo additionalItemInfo)
    {
        this.IconGUID = IconGUID;
        this.DisplayName = displayName; 
        this.MaxLevel = maxLevel;
        this.Level = level;
        this.itemType = itemType;
        this.classType = classType;
        this.additionalItemInfo = additionalItemInfo;
    }

    public int CostFunction()
    {
        return Cost * Level;
    }
}

[Serializable]
public class AdditionalItemInfo
{
    public Interval<float> DamageBounds;
}

[CreateAssetMenu(fileName = "ItemSO", menuName = "ItemSO/ItemSO", order = 1)]
public class ItemSO : ScriptableObject
{
    [field: SerializeField] public string DisplayName { private set; get; }
    [field: SerializeField] public AssetReference Icon { private set; get; }
    [field: SerializeField] public ItemType ItemType { private set; get; }
    [field: SerializeField] public ClassType ClassType { private set; get; }
    [field: SerializeField] public AdditionalItemInfo AdditionalItemInfo { private set; get; }
}

[Serializable]
public enum ItemType
{
    WEAPON,
    ARMOR,
    SKILL
}

[System.Serializable]
public enum ClassType
{
    ALL,
    MELEE,
    RANGED,
    MAGE,
    HEALER,
}