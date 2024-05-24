using GordonEssentials.Types;
using System;
using UnityEngine;
using UnityEngine.AddressableAssets;

[CreateAssetMenu(fileName = "ItemSO", menuName = "ItemSO/ItemSO", order = 1)]
public class ItemSO : ScriptableObject
{
    [field: SerializeField] public string DisplayName { get; private set; }
    [field: SerializeField] public AssetReferenceSprite Icon { get; private set; }
    [field: SerializeField] public int MaxLevel {  get; private set; }
    [field: SerializeField] public int Cost { get; private set; }
    [field: SerializeField] public CharacterStats StatsModifiers { get; private set; }

}
