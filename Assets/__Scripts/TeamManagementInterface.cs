using GordonEssentials;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class TeamManagementInterface : Singleton<TeamManagementInterface>
{
    public CharacterPanel CharacterPanel;

    [SerializeField] TMP_Text money;
    [SerializeField] Button moneyButton;
    [SerializeField] Button returnBtn;

    [SerializeField] CharacterView CharacterViewPrefab;
    [SerializeField] Transform charactersPartent;

    private void ReturnBehaviour()
    {
        SceneLoader.Instance.LoadScene(SceneConstants.ChooseLevelScene);
    }
    private void Start()
    {
        ResourcesHolder.OnResourcesUpdated += UpdateResourcesDisplay;
        returnBtn.onClick.AddListener(ReturnBehaviour);
        CharacterPanel.gameObject.SetActive(false);


        UpdateResourcesDisplay(SavableDataManager.Instance.data.playerResources);
        FillStartingCharacters();

        //Dev
        moneyButton.onClick.AddListener(() => SavableDataManager.Instance.data.playerResources.AddMoney(500));
    }

    private void OnDisable()
    {
        ResourcesHolder.OnResourcesUpdated -= UpdateResourcesDisplay;
    }

    private void UpdateResourcesDisplay(ResourcesHolder holder)
    {
        money.text = holder.Money.ToString();
    }

    private void FillStartingCharacters()
    {
        Team currentTeam = SavableDataManager.Instance.data.team;
        SpawnAndSetCharacter(currentTeam.General);

        foreach (var member in currentTeam.TeamMembers)
        {
            SpawnAndSetCharacter(member);
        }
    }

    void SpawnAndSetCharacter(Character character)
    {
        CharacterView characterView = Instantiate(CharacterViewPrefab, charactersPartent);
        characterView.SetCharacter(character);
    }

    public void SetCurrentCharacterDisplay(Character character)
    {
        CharacterPanel.SetupView(character);
        CharacterPanel.gameObject.SetActive(true);
    }
}
