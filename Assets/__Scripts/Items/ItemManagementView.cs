using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

public class ItemManagementView : MonoBehaviour
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
            Init(item);
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
        new AssetReference(displayable.IconGUID).LoadAssetAsync<Sprite>().Completed += handle => { icon.sprite = handle.Result; };
    }

    public void RestartDisplay()
    {
        icon.sprite = null;
        displayName.text = "";
    }
}
