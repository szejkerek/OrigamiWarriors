using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

[CreateAssetMenu(fileName = "NewCharacter", menuName = "CharacterCreator/Character", order = 0)]
public class CharacterSO : ScriptableObject
{
    [field: SerializeField] public AssetReference Icon { private set; get; }
    [field: SerializeField] public string DisplayName { private set; get; }
    [field: SerializeField] public GameObject CharacterGameObject { private set; get; }
    [field: SerializeField] public CharacterStats BaseStats { private set; get; }
    [field: SerializeField] public List<UpgradableStatSO> Stats { private set; get; }
    [field: SerializeField] public AssetReferenceItemSO Weapon { private set; get; }
    [field: SerializeField] public AssetReferenceItemSO Armor { private set; get; }
    [field: SerializeField] public AssetReferenceItemSO Skill { private set; get; }

    public List<UpgradableStat> CreateStats()
    {
        List<UpgradableStat> statsList = new List<UpgradableStat>();
        foreach (UpgradableStatSO stat in Stats)
        {
            statsList.Add(new UpgradableStat(stat));
        }
        return statsList;
    }
}
