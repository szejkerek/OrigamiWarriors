using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class TeamManagementInterface : Singleton<TeamManagementInterface>
{
    public CharacterPanel CharacterPanel;

    [SerializeField] TMP_Text money;
    [SerializeField] Button returnBtn;

    [SerializeField] CharacterView CharacterViewPrefab;
    [SerializeField] Transform charactersPartent;
    List<CharacterView> characterViews = new List<CharacterView>();
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
        FillCharacterSlots();
    }

    private void OnDisable()
    {
        ResourcesHolder.OnResourcesUpdated -= UpdateResourcesDisplay;
    }

    private void UpdateResourcesDisplay(ResourcesHolder holder)
    {
        money.text = holder.Money.ToString();
    }

    private void FillCharacterSlots()
    {
        characterViews.Clear();
        Team currentTeam = SavableDataManager.Instance.data.team;
        SpawnAndSetCharacter(currentTeam.General, select:true);
        
        foreach (var member in currentTeam.TeamMembers)
        {
            SpawnAndSetCharacter(member);
        }
    }

    void SpawnAndSetCharacter(Character character, bool select = false)
    {
        CharacterView characterView = Instantiate(CharacterViewPrefab, charactersPartent);
        characterView.SetCharacter(character);
        characterViews.Add(characterView);

        if(select)
        {
            CharacterPanel.SetupView(character);
            characterView.EnableBorder();
        }
    }
}
