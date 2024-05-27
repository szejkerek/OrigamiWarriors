using GordonEssentials.Types;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

public class CharacterView : MonoBehaviour
{
    [SerializeField] Button characterBtn;
    [SerializeField] Button returnBtn;
    [SerializeField] Image characterIcon;
    [SerializeField] TMP_Text characterName;

    [SerializeField] GameObject textDisplay;

    Character character;

    private void Awake()
    {
        ResetView();
        characterBtn.onClick.AddListener(CharacterBehavior);
        returnBtn.onClick.AddListener(ResetView);
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

    private void CharacterBehavior()
    {
        if (character != null)
        {
            TeamManagementInterface.Instance.SetCurrentCharacterDisplay(character);
        }
        //else
        //{
        //    SetCharacter(SavableDataManager.Instance.data.characters.SelectRandomElement());
        //}
    }

    public void SetCharacter(IDisplayable character)
    {
        this.character = character as Character;
        characterIcon.gameObject.SetActive(true);
        new AssetReference(character.IconGUID).LoadAssetAsync<Sprite>().Completed += handle => { characterIcon.sprite = handle.Result; };
        returnBtn.gameObject.SetActive(true);
        textDisplay.gameObject.SetActive(true);
        characterName.text = character.DisplayName;
    }


}
