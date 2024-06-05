using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class VoiceCommand : ScriptableObject
{
    [field: SerializeField] public List<string> Commands { get; private set; }
    [field: SerializeField] public float Cooldown { get; private set; }
    public abstract void Execute();

    protected float lastCommand;
    protected bool IsCommandOffCooldown()
    {
        if(lastCommand + Cooldown < Time.time)
        {
            lastCommand = Time.time;
            return true;
        }
        Debug.Log("Command is on cooldown.");
        return false;
    }
}
