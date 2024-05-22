using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

public class UpgradeableItemDisplay : MonoBehaviour
{
    [SerializeField] Image icon;
    [SerializeField] TMP_Text displayName;
    UpgradeableComponent UpgradeableComponent;

    public void Init<T>(T item) where T : IDisplayable, IUpgradable
    {
        SetupDisplay(item);
        SetupUpgradable(item);
    }

    void SetupUpgradable(IUpgradable upgradebleItem)
    {
        UpgradeableComponent = GetComponentInChildren<UpgradeableComponent>();
        UpgradeableComponent?.Init(upgradebleItem);
    }

    void SetupDisplay(IDisplayable displayable)
    {        
        displayName.text = displayable.DisplayName;
        new AssetReference(displayable.IconGUID).LoadAssetAsync<Sprite>().Completed += handle => { icon.sprite = handle.Result; };
    }
}
