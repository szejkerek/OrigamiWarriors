using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Voice VoicePhrases/Attack Big Command")]
public class AttackBigCommand : VoiceCommand
{
  public static Action<AttackBigCommand> OnAttackBigRecognized;
  public override void Execute()
  {
    if (IsCommandOffCooldown())
    {
      OnAttackBigRecognized?.Invoke(this);
    }
  }
}
