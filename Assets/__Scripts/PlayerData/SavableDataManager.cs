using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class SavableDataManager : Singleton<SavableDataManager>, ISavable
{    
    public SaveableData data = new SaveableData();
    [SerializeField] TeamSO team;
    protected override void Awake()
    {
        base.Awake();
        data.team = new Team(team);
        Save();
        Load();
    }

    #region Save Logic
    public string SavedFilename => "data.dat";

    public void Load()
    {
        data = SaveManager<SaveableData>.Load(SavedFilename);
        Save();
    }

    public void Save()
    {
        SaveManager<SaveableData>.Save(data, SavedFilename);
    }
    #endregion
}
