using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Voice VoicePhrases/Defense Command")]
public class DefenseCommand : VoiceCommand
{
    public static Action<DefenseCommand> OnDefenseRecognized;
    public override void Execute()
    {
        if(IsCommandOffCooldown())
        {
            OnDefenseRecognized?.Invoke(this);
        }
    }
}