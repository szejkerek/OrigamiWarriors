using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;
//
public class ChoiceUI : MonoBehaviour
{
    public static Action<IDisplayable> OnChoiceSelected;
    [SerializeField] Button choiceBtn;
    [SerializeField] GameObject selectedBorder;
    [SerializeField] CharacterUIDisplay characterDisplay;

    IDisplayable choiceItem;

    public void Init(Character character)
    {
        selectedBorder.SetActive(false);
        this.choiceItem = character;
        characterDisplay.Init(character);
        choiceBtn.onClick.AddListener(SelectChoice);
        OnChoiceSelected += DisableBorder;
    }

    public void EnableBorder()
    {
        selectedBorder.SetActive(true);
    }

    void DisableBorder(IDisplayable _)
    {
        selectedBorder.SetActive(false);
    }

    private void SelectChoice()
    {
        OnChoiceSelected?.Invoke(choiceItem);
        selectedBorder.SetActive(true);
    }

    private void OnDisable()
    {
        characterDisplay.Clear();
        OnChoiceSelected -= DisableBorder;
    }

}
