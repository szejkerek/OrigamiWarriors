using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat 
{
    Sprite icon;
    string displayName;
    int maxLevel;
    bool isUpgradeable;

    #region Constructors
    public Stat(StatSO data)
    {
        icon = data.Icon;
        displayName = data.DisplayName;
        maxLevel = data.MaxLevel;
        isUpgradeable = data.IsUpgradeable;
    }
    public Stat(Sprite icon, string displayName, int maxLevel, bool isUpgradeable)
    {
        this.icon = icon;
        this.displayName = displayName; 
        this.maxLevel = maxLevel;
        this.isUpgradeable = isUpgradeable;
    }
    #endregion

}
