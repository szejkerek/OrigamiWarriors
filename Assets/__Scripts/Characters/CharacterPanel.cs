using System;
using TMPro;
using UnityEngine;

public class CharacterPanel : MonoBehaviour
{
    public Character CurrentCharacter;

    [SerializeField] TMP_Text characterName;

    [SerializeField] StatsPanel statsPanel;

    [SerializeField] ItemView[] itemSlot = new ItemView[3];
    private void Awake()
    {
        gameObject.SetActive(false);
        CharacterView.OnCharacterSelected += SetupView;
    }

    private void OnDisable()
    {
        CharacterView.OnCharacterSelected -= SetupView;
    }

    public void SetupView(Character character)
    {
        gameObject.SetActive(true);

        CurrentCharacter = character;
        characterName.text = character.Name;
        statsPanel.Init(character);

        for (int i = 0; i < 3; i++)
        {
            itemSlot[i].Init(character.Items[i]);

        }
    }
}
