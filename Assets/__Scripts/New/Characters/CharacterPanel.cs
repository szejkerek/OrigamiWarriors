using System;
using TMPro;
using UnityEngine;

public class CharacterPanel : MonoBehaviour
{
    Character character;
    [SerializeField] TMP_Text characterName;

    [SerializeField] TMP_Text statsDisplay;

    [SerializeField] ItemManagementView weaponSlot;
    [SerializeField] ItemManagementView armorSlot;
    [SerializeField] ItemManagementView skillSlot;

    public void SetupView(Character character)
    {
        this.character = character;
        characterName.text = character.DisplayName;
        statsDisplay.text = character.GetStats().DisplayText();
        SetupItems();
    }

    private void SetupItems()
    {
        weaponSlot.Init(character.weapon);
        armorSlot.Init(character.armor);
        skillSlot.Init(character.skill);
    }
}
