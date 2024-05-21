public interface IUpgradable
{
    int MaxLevel { get; }
    int Level { get; set; }

    int CostFunction();

    void Upgrade();

    void ResetLevel()
    {
        Level = 0;
    }
}