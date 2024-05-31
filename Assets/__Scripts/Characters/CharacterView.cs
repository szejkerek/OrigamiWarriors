using System;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

public class CharacterView : MonoBehaviour
{
    public static Action<Character> OnCharacterSelected;
    [SerializeField] Button characterBtn;
    [SerializeField] Button returnBtn;
    [SerializeField] SamuraiImages viusals;
    [SerializeField] TMP_Text characterName;

    [SerializeField] GameObject textDisplay;
    [SerializeField] GameObject selectedBorder;

    Character character;

    private void Awake()
    {
        ResetView();
        selectedBorder.SetActive(false);
        characterBtn.onClick.AddListener(SelectCharacter);
        OnCharacterSelected += DisableBorder;

        returnBtn.onClick.AddListener(ResetView);
    }
    public void EnableBorder()
    {
        selectedBorder.SetActive(true);
    }

    void DisableBorder(Character _)
    {
        selectedBorder.SetActive(false);
    }

    private void OnDisable()
    {
        OnCharacterSelected -= DisableBorder;
    }

    public void SelectCharacter()
    {
        OnCharacterSelected?.Invoke(character); 
        selectedBorder.SetActive(true);
    }

    void ResetView()
    {
        TeamManagementInterface.Instance.CharacterPanel.CurrentCharacter = null;
        character = null;
        returnBtn.gameObject.SetActive(false);
        viusals.SetActive(false);
        textDisplay.gameObject.SetActive(false);
    }

    

    public void SetCharacter(Character character)
    {
        this.character = character;
        viusals.SetActive(true);
        character.SamuraiVisuals.Apply(viusals, character);
        returnBtn.gameObject.SetActive(true);
        textDisplay.gameObject.SetActive(true);
        characterName.text = character.DisplayName;
    }


}
