using System;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;
//
public class ChoiceUI : MonoBehaviour
{
    public static Action<Character> OnCharacterSelected;
    [SerializeField] Button choiceBtn;
    [SerializeField] GameObject selectedBorder;
    [SerializeField] CharacterUIDisplay characterDisplay;
    [SerializeField] TooltipTrigger tooltipTrigger;

    Character choiceItem;

    public void Init(Character character)
    {
        
        selectedBorder.SetActive(false);
        this.choiceItem = character;
        characterDisplay.Init(character);
        choiceBtn.onClick.AddListener(SelectChoice);
        OnCharacterSelected += DisableBorder;

        CharacterStats stats = character.GetStats();
        string content = $"Damage: {stats.Damage:0}\n" +
        $"Health: {stats.MaxHealth}\n" +
        $"Armor: {stats.Armor:0}\n" +
               $"Movement Speed: {stats.Speed:0}\n" +
               $"Crit Chance: {stats.CritChance * 100:0}%\n";

        tooltipTrigger.SetContent(character.Name, content);
    }

    public void EnableBorder()
    {
        selectedBorder.SetActive(true);
    }

    void DisableBorder(Character _)
    {
        selectedBorder.SetActive(false);
    }

    private void SelectChoice()
    {
        OnCharacterSelected?.Invoke(choiceItem);
        selectedBorder.SetActive(true);
    }

    private void OnDisable()
    {
        characterDisplay.Clear();
        OnCharacterSelected -= DisableBorder;
    }

}
