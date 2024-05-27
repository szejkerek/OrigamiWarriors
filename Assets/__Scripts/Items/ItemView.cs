using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class ItemView : MonoBehaviour
{
    [SerializeField] Image icon;
    [SerializeField] TMP_Text displayName;
    UpgradeableComponent UpgradeableComponent;
    Item currentItem;
    private void Awake()
    {
        UpgradeableComponent = GetComponentInChildren<UpgradeableComponent>();
        UpgradeableComponent.OnMaxedLevel += TryEvolve;
    }

    private void OnDestroy()
    {
        UpgradeableComponent.OnMaxedLevel -= TryEvolve;
    }

    private void TryEvolve()
    {
        Item item = currentItem.TryGetNextItem();
        if (item != null)
        {
            Character currentCharacter = TeamManagementInterface.Instance.currentCharacter;
            if(currentCharacter != null)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (currentCharacter.items[i] == currentItem)
                    {
                        currentCharacter.items[i] = item;
                    }
                }
                Init(item);
            }
        }
        else
        {
            UpgradeableComponent.BlockUpgrades();
        }
    }

    public void Init(Item item)
    {
        currentItem = item;
        SetupDisplay(item);
        SetupUpgradable(item);
    }

    void SetupUpgradable(Item upgradebleItem)
    {
        UpgradeableComponent?.Init(upgradebleItem);
    }

    void SetupDisplay(IDisplayable displayable)
    {
        displayName.text = displayable.DisplayName;

        Color iconColor = icon.color;
        iconColor.a = 0;
        icon.color = iconColor;

        var iconReference = new AssetReference(displayable.IconGUID);
        iconReference.LoadAssetAsync<Sprite>().Completed += handle =>
        {
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                icon.sprite = handle.Result;
                iconColor.a = 1;
                icon.color = iconColor;
            }
            else
            {
                Debug.LogError("Failed to load icon sprite.");
            }
        };
    }

    public void RestartDisplay()
    {
        icon.sprite = null;
        displayName.text = "";
    }
}
