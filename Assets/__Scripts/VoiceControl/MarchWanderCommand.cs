using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Voice VoicePhrases/March Wander Command")]
public class MarchWanderCommand : VoiceCommand
{
  public static Action<MarchWanderCommand> onWanderRecognized;
  public override void Execute()
  {
    if (Cooldown.IsCommandOffCooldown())
    {
      onWanderRecognized?.Invoke(this);
    }
  }
}
