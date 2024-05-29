using UnityEngine;

public class SavableDataManager : Singleton<SavableDataManager>
{
    public SaveableData data;
    [SerializeField] TeamSO team;

    protected override void Awake()
    {
        base.Awake();
        data = new SaveableData(team);
    }
}
