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
        return $"Damage: {stats.Damage:0}\n" +
               $"Health: {stats.MaxHealth - currentCharacter.LostHealth:0}/{stats.MaxHealth:0} \n" +
               $"Armor: {stats.Armor:0}\n" +
               $"Movement Speed: {stats.Speed:0}\n" +
               $"Crit Chance: {stats.CritChance * 100:0}%\n";
    }
}
