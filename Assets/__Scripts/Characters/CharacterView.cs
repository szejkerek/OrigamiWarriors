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
    [SerializeField] Image characterIcon;
    [SerializeField] TMP_Text characterName;

    [SerializeField] GameObject textDisplay;
    [SerializeField] GameObject selectedBorder;

    Character character;

    private void Awake()
    {
        ResetView();
        selectedBorder.SetActive(false);
        characterBtn.onClick.AddListener(SelectCharacter);
        OnCharacterSelected += (_) => selectedBorder.SetActive(false);

        returnBtn.onClick.AddListener(ResetView);
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
        characterIcon.sprite = null;
        returnBtn.gameObject.SetActive(false);
        characterIcon.gameObject.SetActive(false);
        textDisplay.gameObject.SetActive(false);
    }

    

    public void SetCharacter(IDisplayable character)
    {
        this.character = character as Character;
        characterIcon.gameObject.SetActive(true);
        new AssetReference(character.DisplayIconGuid).LoadAssetAsync<Sprite>().Completed += handle => { characterIcon.sprite = handle.Result; };
        returnBtn.gameObject.SetActive(true);
        textDisplay.gameObject.SetActive(true);
        characterName.text = character.DisplayName;
    }


}
