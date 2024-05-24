using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;


[CreateAssetMenu(fileName = "NewStat", menuName = "CharacterCreator/UpgradableStat")]

public class UpgradableStatSO : ScriptableObject
{
    [field: SerializeField] public AssetReference Icon { private set; get; }
    [field: SerializeField] public string DisplayName { private set; get; }
    [field: SerializeField] public int MaxLevel { private set; get; }
    [field: SerializeField] public int Cost { private set; get; }
}