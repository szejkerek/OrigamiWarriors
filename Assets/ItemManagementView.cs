using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class ItemManagementView : MonoBehaviour
{
    [SerializeField] Image icon;
    [SerializeField] Button upgradeButton;
    [SerializeField] TMP_Text displayName;
    [SerializeField] Transform segmentsParent;
    [SerializeField] StatSegment statSegmentPrefab;

    List<StatSegment> segments = new List<StatSegment>();

    Item item;
    public void SetupDisplay(Item stat)
    {
        this.stat = stat;
        displayName.text = this.stat.DisplayName;
        //AssetReference asset = new AssetReference(stat.IconGUID);
        asset.LoadAssetAsync<Sprite>().Completed += OnAssetLoaded;

        upgradeButton.onClick.AddListener(TryUpgradeItem);

        CreateSegments();
        UpdateView();
    }

    private void TryUpgradeItem()
    {
        throw new NotImplementedException();
    }

    void OnAssetLoaded(AsyncOperationHandle<Sprite> handle)
    {
        icon.sprite = handle.Result;
    }

    void CreateSegments()
    {
        segments.Clear();
        for (int i = 0; i < item.MaxLevel; i++)
        {
            StatSegment segment = Instantiate(statSegmentPrefab, segmentsParent);
            segments.Add(segment);
        }
    }

    

    void UpdateView()
    {
        for (int i = 0; i < stat.Level; i++)
        {
            segments[i].Activate();
        }

        if (!stat.CanBeUpgraded())
        {
            upgradeButton.gameObject.SetActive(false);
        }
    }
}
