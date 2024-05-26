using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeableComponent : MonoBehaviour
{
    public static Action OnUpgrade;
    [SerializeField] UpgradableSegment SegmentPrefab;
    [SerializeField] Transform segmentsParent;
    [SerializeField] Button upgradeButton;

    IUpgradable upgradable;
    List<UpgradableSegment> segments = new List<UpgradableSegment>();

    private void Awake()
    {
        upgradeButton.onClick.AddListener(TryUpgrade);
        ResourcesHolder.OnResourcesUpdated += UpdateView;
    }

    private void OnDestroy()
    {
        ResourcesHolder.OnResourcesUpdated -= UpdateView;
    }

    private void TryUpgrade()
    {
        int cost = upgradable.CostFunction();

        if (upgradable.Level >= upgradable.MaxLevel)
        {
            Debug.LogWarning($"{upgradable} is already maxed, cannot upgrade it.");
            UpdateView();
            return;
        }

        if (SavableDataManager.Instance.data.playerResources.TryRemoveMoney(cost))
        {
            upgradable.Level++;
            OnUpgrade?.Invoke();
        }
        else
        {
            Debug.LogWarning($"Not enough money to upgrade {upgradable}");
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
        DestroySegments();
        for (int i = 0; i < upgradable.MaxLevel; i++)
        {
            UpgradableSegment segment = Instantiate(SegmentPrefab, segmentsParent);
            segments.Add(segment);
        }
        UpdateView();
    }

    void DestroySegments()
    {
        foreach (Transform t in segmentsParent)
        {
            Destroy(t.gameObject);
        }
        segments.Clear();
    }

    void UpdateView()
    {
        if (segments.Count == 0)
            return;

        for (int i = 0; i < upgradable.Level; i++)
        {
            segments[i].Activate();
        }
    }
}
