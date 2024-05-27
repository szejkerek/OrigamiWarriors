using System;
using TMPro;
using UnityEngine;

public class CharacterPanel : MonoBehaviour
{
    Character character;
    [SerializeField] TMP_Text characterName;

    [SerializeField] StatsPanel statsPanel;

    [SerializeField] ItemView[] itemSlot = new ItemView[3];

    public void SetupView(Character character)
    {
        this.character = character;
        characterName.text = character.DisplayName;
        statsPanel.Init(character);

        for (int i = 0; i < 3; i++)
        {
            itemSlot[i].Init(character.items[i]);

        }
    }
}
