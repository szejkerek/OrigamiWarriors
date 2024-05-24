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
        this.itemDataGuid = itemDataGuid;
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

internal interface IUseVoice
{
    void SubscribeToVoiceAction();
    void UnsubscribeFromVoiceAction();
}

[Serializable]
public class AdditionalItemInfo
{
    public Interval<float> DamageBounds;
}

[CreateAssetMenu(fileName = "ItemSO", menuName = "ItemSO/ItemSO", order = 1)]
public class ItemSO : ScriptableObject, IConstStatsModifier
{
    [field: SerializeField] public string DisplayName { get; private set; }
    [field: SerializeField] public AssetReferenceSprite Icon { get; private set; }
    [field: SerializeField] public int MaxLevel {  get; private set; }
    [field: SerializeField] public int Level { get; private set; }
    [field: SerializeField] public int Cost { get; private set; }
    [field: SerializeField] public ItemType ItemType { get; private set; }
    [field: SerializeField] public ClassType ClassType { get; private set; }
    [field: SerializeField] public AdditionalItemInfo AdditionalItemInfo { get; private set; }

    public void ApplyConstModifiers(CharacterStats stats)
    {
        stats.Health += 150;
    }

    public void RemoveConstModifiers(CharacterStats stats)
    {
        stats.Health -= 150;
    }
}

internal interface IConstStatsModifier
{
    void ApplyConstModifiers(CharacterStats stats);
    void RemoveConstModifiers(CharacterStats stats);
}

internal interface IRatioStatsModifier
{
    void ApplyRatioModifiers(CharacterStats stats);
    void RemoveRatioModifiers(CharacterStats stats);
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