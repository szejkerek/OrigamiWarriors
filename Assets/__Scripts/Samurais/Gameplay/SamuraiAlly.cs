using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class SamuraiAlly : Samurai
{
    protected override void Start()
    {
        base.Start();
        GetComponent<NavMeshAgent>().speed = Character.GetStats().Speed;
    }

}
