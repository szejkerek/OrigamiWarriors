using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;


[CreateAssetMenu(fileName = "NewStat", menuName = "CharacterCreator/Stat")]

public class StatSO : ScriptableObject
{
    [field: SerializeField] public AssetReference Icon { private set; get; }
    [field: SerializeField] public string DisplayName { private set; get; }
    [field: SerializeField] public int MaxLevel { private set; get; }
    [field: SerializeField] public int Cost { private set; get; }

    public Stat CreateStat()
    {
        return new Stat(Icon.AssetGUID, DisplayName, MaxLevel, Cost, currentLevel: 0);
    }
}