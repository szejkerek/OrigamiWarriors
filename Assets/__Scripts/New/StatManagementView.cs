using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class StatManagementView : MonoBehaviour
{
    [SerializeField] Image icon;
    [SerializeField] TMP_Text displayName;

    Stat stat;
    UpgradeableComponent UpgradeableComponent;

    public void SetupDisplay(Stat stat)
    {
        this.stat = stat;
        displayName.text = this.stat.DisplayName;

        UpgradeableComponent = GetComponentInChildren<UpgradeableComponent>();
        UpgradeableComponent.Init(stat);

        AssetReference asset = new AssetReference(stat.IconGUID);
        asset.LoadAssetAsync<Sprite>().Completed += handle => { icon.sprite = handle.Result; };
    }

}
