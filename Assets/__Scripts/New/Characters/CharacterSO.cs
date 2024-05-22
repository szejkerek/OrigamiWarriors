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
    [field: SerializeField] public List<StatSO> Stats { private set; get; }

    public Character CreateCharacter()
    {
        return new Character(Icon.AssetGUID, DisplayName, CharacterGameObject, CreateStats());
    }

    public List<Stat> CreateStats()
    {
        List<Stat> statsList = new List<Stat>();
        foreach (StatSO stat in Stats)
        {
            statsList.Add(new Stat(stat));
        }
        return statsList;
    }
}
