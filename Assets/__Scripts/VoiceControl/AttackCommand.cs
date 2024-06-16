﻿using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Voice VoicePhrases/Attack Command")]
public class AttackCommand : VoiceCommand
{
    public static Action<AttackCommand> OnAttackRecognized;
    public override void Execute()
    {
        if (IsCommandOffCooldown())
        {
            OnAttackRecognized?.Invoke(this);
        }
    }
}
