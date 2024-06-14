using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

[CreateAssetMenu(fileName = "NewCharacter", menuName = "Character/Character", order = 0)]
public class CharacterSO : ScriptableObject
{
    [field: SerializeField] public AssetReference Icon { private set; get; }
    [field: SerializeField] public string Name { private set; get; }
    [field: SerializeField] public SamuraiVisualsSO SamuraiVisuals { private set; get; }
    [field: SerializeField] public GameObject CharacterGameObject { private set; get; }
    [field: SerializeField] public CharacterStats BaseStats { private set; get; }
    [field: SerializeField] public List<PassiveEffect> PassiveEffects { private set; get; }
    [field: SerializeField] public AssetReferenceItemSO Weapon { private set; get; }
    [field: SerializeField] public AssetReferenceItemSO Armor { private set; get; }
    [field: SerializeField] public AssetReferenceItemSO Skill { private set; get; }
}
