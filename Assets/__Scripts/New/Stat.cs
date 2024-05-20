using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat
{
    public string IconGUID { get; private set; }
    public string DisplayName { get; private set; }
    public int MaxLevel { get; private set; }
    public bool IsUpgradeable { get; private set; }

    public int Level => currentLevel;
    int currentLevel = 0;

    #region Constructors
    public Stat(StatSO data) : this(data.Icon.AssetGUID, data.DisplayName, data.MaxLevel, data.IsUpgradeable, currentLevel: 0) {  }

    public Stat(string IconGUID, string displayName, int maxLevel, bool isUpgradeable, int currentLevel)
    {
        this.IconGUID = IconGUID;
        this.DisplayName = displayName;
        this.MaxLevel = maxLevel;
        this.IsUpgradeable = isUpgradeable;
        this.currentLevel = currentLevel;
    }
    #endregion

    public int GetCurrentCost()
    {
        return currentLevel;
    }

    public bool IncrementLevel()
    {
        if(!CanBeUpgraded())
        {
            Debug.LogWarning($"Stat {DisplayName} cannot be upgraded.");
            return false;
        }

        currentLevel++;
        return true;
    }

    public void ResetLevel()
    {
        currentLevel = 0;
    }

    public bool CanBeUpgraded()
    {
        bool underMaxLevel = currentLevel < MaxLevel;
        return underMaxLevel;
    }
}
