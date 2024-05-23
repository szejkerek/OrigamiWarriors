using GordonEssentials.Types;
using System;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class Item : IDisplayable, IUpgradable
{
    public string IconGUID { get; }
    public string DisplayName { get; }
    public int MaxLevel { get; }
    public int Level { get; set; }
    public int Cost { get; }
    public ItemSO itemData {  get; }

    string itemDataGuid;

    public Item(string itemDataGuid)
    {
        itemData = new AssetReferenceItemSO(itemDataGuid).LoadAssetAsync<ItemSO>().WaitForCompletion();
        this.IconGUID = itemData.Icon.AssetGUID;
        this.DisplayName = itemData.DisplayName;
        this.MaxLevel = itemData.MaxLevel;
        this.Level = itemData.Level;
        this.Cost = itemData.Cost;
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
    [field: SerializeField] public string DisplayName { get; private set; }
    [field: SerializeField] public AssetReferenceSprite Icon { get; private set; }
    [field: SerializeField] public int MaxLevel {  get; private set; }
    [field: SerializeField] public int Level { get; private set; }
    [field: SerializeField] public int Cost { get; private set; }
    [field: SerializeField] public ItemType ItemType { get; private set; }
    [field: SerializeField] public ClassType ClassType { get; private set; }
    [field: SerializeField] public AdditionalItemInfo AdditionalItemInfo { get; private set; }
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