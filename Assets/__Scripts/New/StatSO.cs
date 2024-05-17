using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewStat", menuName = "CharacterCreator/Stat")]

public class StatSO : ScriptableObject
{
    [field: SerializeField] public Sprite Icon { private set; get; }
    [field: SerializeField] public string DisplayName { private set; get; }
    [field: SerializeField] public int MaxLevel { private set; get; }
    [field: SerializeField] public bool IsUpgradeable { private set; get; }
}