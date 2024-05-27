using GordonEssentials;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavableDataManager : Singleton<SavableDataManager>
{
    [HideInInspector] public SaveableData data;

    [SerializeField] TeamSO team;

    protected override void Awake()
    {
        base.Awake();
        data = new SaveableData(team);
    }
}
