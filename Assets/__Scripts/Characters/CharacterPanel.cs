using System;
using TMPro;
using UnityEngine;

public class CharacterPanel : MonoBehaviour
{
    public Character CurrentCharacter;

    [SerializeField] TMP_Text characterName;

    [SerializeField] StatsPanel statsPanel;

    [SerializeField] ItemView[] itemSlot = new ItemView[3];

    public void SetupView(Character character)
    {
        CurrentCharacter = character;
        characterName.text = character.DisplayName;
        statsPanel.Init(character);

        for (int i = 0; i < 3; i++)
        {
            itemSlot[i].Init(character.Items[i]);

        }
    }
}
