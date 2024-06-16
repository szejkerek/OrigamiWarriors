using System.Collections.Generic;
using UnityEngine;

public abstract class VoiceCommand : ScriptableObject
{
    [field: SerializeField] public string DisplayPhrase { get; private set; }
    [field: SerializeField] public List<string> VoicePhrases { get; private set; }
    [field: SerializeField] public float Cooldown { get; private set; }
    public abstract void Execute();

    float lastCommand;

    public void ResetTimers()
    {
        lastCommand = Time.time - Cooldown;
    }

    protected bool IsCommandOffCooldown()
    {
        Debug.Log("Checking cooldown for command: " + DisplayPhrase);
        if (ReadyToUseRatio() == 1)
        {
            lastCommand = Time.time;
            Debug.Log("Command off cooldown: " + DisplayPhrase);
            return true;
        }
        Debug.Log("Command still on cooldown: " + DisplayPhrase);
        return false;
    }

    public float ReadyToUseRatio()
    {      
        float timeSinceLastCommand = Time.time - lastCommand;
        float ratio = Mathf.Clamp01(timeSinceLastCommand / Cooldown);
        return ratio;
    }
}
