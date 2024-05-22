using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCharacter", menuName = "CharacterCreator/Caharacter", order = 0)]
public class CharacterSO : ScriptableObject
{
    [field: SerializeField] public Sprite Icon { private set; get; }
    [field: SerializeField] public string DisplayName { private set; get; }
    [field: SerializeField] public GameObject CharacterGameObject { private set; get; }
    [field: SerializeField] public List<StatSO> Stats { private set; get; }
}
