using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Voice VoicePhrases/Stay Idle Command")]
public class StayIdleCommand : VoiceCommand
{
  public static Action<StayIdleCommand> OnIdleBigRecognized;
  public override void Execute()
  {
    if (IsCommandOffCooldown())
    {
      OnIdleBigRecognized?.Invoke(this);
    }
  }
}
