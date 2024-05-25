using GordonEssentials;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavableDataManager : Singleton<SavableDataManager>
{
    [HideInInspector] public SaveableData data;
    public List<AssetReferenceCharacterSO> startingCharacters = new List<AssetReferenceCharacterSO>();

    protected override void Awake()
    {
        base.Awake();
        foreach (var member in startingCharacters)
        {
            data.characters.Add(new Character(member.AssetGUID));
        }
    }


}
