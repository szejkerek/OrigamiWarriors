using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeamMember : MonoBehaviour
{
    [SerializeField] Button characterBtn;
    [SerializeField] Button returnBtn;
    [SerializeField] Image characterIcon;

    Character character;
    
    public void SetCharacter(Character character)
    {
        this.character = character;
        characterIcon.sprite = character.icon;
    }
}
