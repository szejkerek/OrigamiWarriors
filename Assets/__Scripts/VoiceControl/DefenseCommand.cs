using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Voice Commands/Defense Command")]
public class DefenseCommand : VoiceCommand
{
    public static Action OnDefenseRecognized;
    public override void Execute()
    {
        if(IsCommandOffCooldown())
        {

        }
        OnDefenseRecognized?.Invoke();
    }
}