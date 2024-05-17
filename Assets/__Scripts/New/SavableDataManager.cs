using GordonEssentials;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavableDataManager : Singleton<SavableDataManager>
{
    [HideInInspector] public SaveableData data;
    public List<CharacterSO> startingCharacters = new List<CharacterSO>();

    protected override void Awake()
    {
        base.Awake();
        foreach (CharacterSO member in startingCharacters)
        {
            data.characters.Add(new Character(member));
        }
    }


}
