using GordonEssentials;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamManagementInterface : Singleton<TeamManagementInterface> 
{
    public Character currentCharacter;
    [SerializeField] CharacterPanel characterPanel;
    [SerializeField] List<TeamMemberInterface> charactersSlot;

    private void Start()
    {
        FillStartingCharacters();
    }

    private void FillStartingCharacters()
    {
        List<Character> savedCharacters = SavableDataManager.Instance.data.characters;
        for (int i = 0; i < charactersSlot.Count && i < savedCharacters.Count; i++)
        {
            charactersSlot[i].SetCharacter(savedCharacters[i]);
        }
    }

    public void SetCurrentCharacterDisplay(Character character)
    {
        currentCharacter = character;
        characterPanel.SetupView(character);
    }
}
