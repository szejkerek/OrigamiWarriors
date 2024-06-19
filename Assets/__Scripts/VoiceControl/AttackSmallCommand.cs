using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Voice VoicePhrases/Attack Small Command")]
public class AttackSmallCommand : VoiceCommand
{
  public static Action<AttackSmallCommand> OnAttackSmallRecognized;
  public override void Execute()
  {
    if (IsCommandOffCooldown())
    {
      OnAttackSmallRecognized?.Invoke(this);
    }
  }
}
