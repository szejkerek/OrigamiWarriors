using GordonEssentials.Types;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Playables;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class CharacterView : MonoBehaviour
{
    [SerializeField] Button characterBtn;
    [SerializeField] Button returnBtn;
    [SerializeField] Image characterIcon;

    Character character;

    private void Awake()
    {
        returnBtn.gameObject.SetActive(false);
        characterBtn.onClick.AddListener(CharacterBehavior);
        returnBtn.onClick.AddListener(ReturnBehavior);
    }

    private void ReturnBehavior()
    {
        TeamManagementInterface.Instance.currentCharacter = null;
        character = null;
        characterIcon.sprite = null;
        returnBtn.gameObject.SetActive(false);
    }

    private void CharacterBehavior()
    {
        if (character != null)
        {
            TeamManagementInterface.Instance.SetCurrentCharacterDisplay(character);
        }
        else
        {
            SetCharacter(SavableDataManager.Instance.data.characters.SelectRandomElement());
        }
    }

    public void SetCharacter(IDisplayable character)
    {
        this.character = character as Character;
        new AssetReference(character.IconGUID).LoadAssetAsync<Sprite>().Completed += handle => { characterIcon.sprite = handle.Result; };
        returnBtn.gameObject.SetActive(true);
    }


}
