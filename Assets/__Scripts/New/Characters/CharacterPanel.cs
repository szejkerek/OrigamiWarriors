using System;
using TMPro;
using UnityEngine;

public class CharacterPanel : MonoBehaviour
{
    Character character;
    [SerializeField] UpgradeableItemDisplay statPrefab;
    [SerializeField] Transform upgradableStatsParent;
    [SerializeField] TMP_Text characterName;

    [SerializeField] ItemManagementView weaponSlot;
    [SerializeField] ItemManagementView armorSlot;
    [SerializeField] ItemManagementView skillSlot;

    private void Awake() => ResetView();

    public void SetupView(Character character)
    {
        this.character = character;
        characterName.text = character.DisplayName;
        
        CreateStats();
        SetupItems();
    }

    private void SetupItems()
    {
        weaponSlot.Init(character.weapon);
        armorSlot.Init(character.armor);
        skillSlot.Init(character.skill);
    }

    void CreateStats()
    {
        ResetView();
        foreach (UpgradableStat s in character.upgradableStats)
        {
            UpgradeableItemDisplay display = Instantiate(statPrefab, upgradableStatsParent);
            display.Init(s);
        }
    }

    void ResetView()
    {
        
        foreach (Transform t in upgradableStatsParent)
        {
            Destroy(t.gameObject);
        }
    }
}
