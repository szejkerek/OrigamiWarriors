using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat 
{
    public Sprite Icon { get; private set; }
    public string DisplayName { get; private set; }
    public int MaxLevel { get; private set; }
    public bool IsUpgradeable { get; private set; }

    #region Constructors
    public Stat(StatSO data)
    {
        Icon = data.Icon;
        DisplayName = data.DisplayName;
        MaxLevel = data.MaxLevel;
        IsUpgradeable = data.IsUpgradeable;
    }
    public Stat(Sprite icon, string displayName, int maxLevel, bool isUpgradeable)
    {
        this.Icon = icon;
        this.DisplayName = displayName; 
        this.MaxLevel = maxLevel;
        this.IsUpgradeable = isUpgradeable;
    }
    #endregion

}
