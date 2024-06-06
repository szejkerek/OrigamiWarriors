using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatsPanel : MonoBehaviour
{
    [SerializeField] TMP_Text text;

    Character currentCharacter;
    void Awake() => UpgradeableComponent.OnUpgrade += RefreshView;
    void OnDestroy() => UpgradeableComponent.OnUpgrade -= RefreshView;

    public void Init(Character character)
    {
        this.currentCharacter = character;
        RefreshView();
    }
    public void RefreshView()
    {
       text.text = DisplayText();
    }

    string DisplayText()
    {
        CharacterStats stats = currentCharacter.GetStats();
        return $"Damage: {stats.Damage}\n" +
               $"Health: {stats.Health}\n" +
               $"Crit Chance: {stats.CritChance * 100}%\n" +
               $"Speed: {stats.Speed}\n";
    }
}
