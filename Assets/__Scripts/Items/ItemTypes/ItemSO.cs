using UnityEngine;
using UnityEngine.AddressableAssets;

public abstract class ItemSO : ScriptableObject
{
    [field: SerializeField] public string DisplayName { get; private set; }
    [field: SerializeField] public AssetReferenceSprite Icon { get; private set; }
    [field: SerializeField] public int MaxLevel {  get; private set; }
    [field: SerializeField] public int Cost { get; private set; }
    [field: SerializeField] public AssetReferenceItemSO NextItem { get; private set; }
    [field: SerializeField] public CharacterStats BaseStats { get; private set; }
    [field: SerializeField] public CharacterStats StatsModifiersPerLevel { get; private set; }

    public CharacterStats CalculateLevelAdditions(int level)
    {      
        return BaseStats + (StatsModifiersPerLevel * level);
    }

    public abstract void Execute();

}