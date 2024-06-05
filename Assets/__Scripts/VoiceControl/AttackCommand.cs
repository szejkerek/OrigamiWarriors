using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Voice Commands/Attack Command")]
public class AttackCommand : VoiceCommand
{
    public static Action OnAttackRecognized;
    public override void Execute()
    {
        OnAttackRecognized?.Invoke();
    }
}
