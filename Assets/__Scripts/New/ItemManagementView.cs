using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemManagementView : MonoBehaviour
{
    [SerializeField] Image icon;
    [SerializeField] Button upgradeButton;
    [SerializeField] TMP_Text displayName;
    [SerializeField] Transform segmentsParent;
    [SerializeField] UpgradableSegment statSegmentPrefab;

    List<UpgradableSegment> segments = new List<UpgradableSegment>();

    Item item;
    //public void SetupDisplay(Item item)
    //{
    //    this.item = item;
    //    displayName.text = this.item.DisplayName;
    //    //AssetReference asset = new AssetReference(stat.IconGUID);
    //    //asset.LoadAssetAsync<Sprite>().Completed += OnAssetLoaded;

    //    upgradeButton.onClick.AddListener(TryUpgradeItem);

    //    CreateSegments();
    //    UpdateView();
    //}

    //private void TryUpgradeItem()
    //{
    //    throw new NotImplementedException();
    //}

    //void OnAssetLoaded(AsyncOperationHandle<Sprite> handle)
    //{
    //    icon.sprite = handle.Result;
    //}

    //void CreateSegments()
    //{
    //    segments.Clear();
    //    //for (int i = 0; i < item.MaxLevel; i++)
    //    {
    //        UpgradableSegment segment = Instantiate(statSegmentPrefab, segmentsParent);
    //        segments.Add(segment);
    //    }
    //}

    

    //void UpdateView()
    //{
    //    //for (int i = 0; i < stat.Level; i++)
    //    {
    //        segments[i].Activate();
    //    }

    //    //if (!stat.CanBeUpgraded())
    //    {
    //        upgradeButton.gameObject.SetActive(false);
    //    }
    //}
}
