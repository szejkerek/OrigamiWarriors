using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class SamuraiAlly : Samurai
{
    public static Action<Samurai> OnDeath;
    protected override void OnSamuraiDeath()
    {
        SavableDataManager.Instance.data.levelResults.deadCharacters.Add(Character);
        OnDeath?.Invoke(this);
    }

    protected override void Start()
    {
        base.Start();
        GetComponent<NavMeshAgent>().speed = GetStats().Speed;
    }

}
