using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeableComponent : MonoBehaviour
{
    [SerializeField] UpgradableSegment SegmentPrefab;
    [SerializeField] Transform segmentsParent;
    [SerializeField] Button upgradeButton;

    IUpgradable upgradable;
    List<UpgradableSegment> segments = new List<UpgradableSegment>();

    private void Awake()
    {
        upgradeButton.onClick.AddListener(TryUpgrade);
    }

    private void TryUpgrade()
    {
        int cost = upgradable.CostFunction();
        if(SavableDataManager.Instance.data.playerResurces.TryRemoveMoney(cost))
        {
            upgradable.Upgrade();
            upgradable.Level++;
        }

        UpdateView();
    }

    public void Init(IUpgradable upgradable)
    {
        this.upgradable = upgradable;
        CreateSegments();
        UpdateView();
    }

    void CreateSegments()
    {
        segments.Clear();
        for (int i = 0; i < upgradable.MaxLevel; i++)
        {
            UpgradableSegment segment = Instantiate(SegmentPrefab, segmentsParent);
            segments.Add(segment);
        }
        UpdateView();
    }

    void UpdateView()
    {
        for (int i = 0; i < upgradable.Level; i++)
        {
            segments[i].Activate();
        }
    }
}
