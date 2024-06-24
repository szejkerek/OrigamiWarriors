using System.Collections.Generic;
using UnityEngine;

public abstract class VoiceCommand : ScriptableObject
{
    [field: SerializeField] public string DisplayPhrase { get; private set; }
    [field: SerializeField] public List<string> VoicePhrases { get; private set; }
    public Cooldown Cooldown = new Cooldown();
    public abstract void Execute();
}

[System.Serializable]
public class Cooldown
{
    public float cooldowTime;
    float last = 0;

    public Cooldown()
    {
        last = 0;
    }

    public void ResetTimers()
    {
        last = Time.time - cooldowTime;
    }

    public bool IsCommandOffCooldown()
    {
        if (ReadyToUseRatio() == 1 || last > Time.time)
        {
            last = Time.time;
            return true;
        }
        return false;
    }

    public float ReadyToUseRatio()
    {
        float timeSinceLastCommand = Time.time - last;
        float ratio = Mathf.Clamp01(timeSinceLastCommand / cooldowTime);
        return ratio;
    }
}