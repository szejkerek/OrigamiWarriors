using UnityEngine;

public abstract class PassiveEffect : ScriptableObject, IPassiveEffect
{
    public virtual void OnStart(SamuraiEffectsManager context) { }

    public virtual void OnUpdate(SamuraiEffectsManager context, float deltaTime) { }
}
