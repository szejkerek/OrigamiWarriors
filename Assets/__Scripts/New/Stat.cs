public class Stat : IUpgradable, IDisplayable
{
    public string IconGUID { get;}
    public string DisplayName { get;}
    public int MaxLevel { get; }
    public int Level { get; set; }
    public int Cost { get; }

    #region Constructors
    public Stat(StatSO data) : this(data.Icon.AssetGUID, data.DisplayName, data.MaxLevel, currentLevel: 0, data.Cost) {  }

    public Stat(string IconGUID, string displayName, int maxLevel, int currentLevel, int cost)
    {
        this.IconGUID = IconGUID;
        this.DisplayName = displayName;
        this.MaxLevel = maxLevel;
        this.Level = currentLevel;
        this.Cost = cost;
    }
    #endregion

    public int CostFunction()
    {
        return Cost;
    }
}
