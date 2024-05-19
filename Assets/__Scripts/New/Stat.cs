using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat 
{
    public Sprite Icon { get; private set; }
    public string DisplayName { get; private set; }
    public int MaxLevel { get; private set; }
    public float Cost { get; private set; }
    public bool IsUpgradeable { get; private set; }
    public int CurrentLevel { get; private set; }

    #region Constructors
    public Stat(StatSO data) : this(data.Icon, data.DisplayName, data.MaxLevel, data.IsUpgradeable, data.CostPerUpdate) { }
 
    public Stat(Sprite icon, string displayName, int maxLevel, bool isUpgradeable, float cost)
    {
        this.Icon = icon;
        this.DisplayName = displayName; 
        this.MaxLevel = maxLevel;
        this.IsUpgradeable = isUpgradeable;
        this.Cost = cost;
        this.CurrentLevel = 0;
    }

    #endregion

}
