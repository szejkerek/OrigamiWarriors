using System;
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

    Character choiceItem;

    public void Init(Character character)
    {
        selectedBorder.SetActive(false);
        this.choiceItem = character;
        characterDisplay.Init(character);
        choiceBtn.onClick.AddListener(SelectChoice);
        OnCharacterSelected += DisableBorder;
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
