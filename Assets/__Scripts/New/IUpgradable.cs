public interface IUpgradable
{
    int MaxLevel { get; }
    int Level { get; set; }
    int Cost { get; }

    int CostFunction();

    void ResetLevel()
    {
        Level = 0;
    }
}