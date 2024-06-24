using UnityEngine;

public abstract class PassiveEffectSO : ScriptableObject, IPassiveEffect
{
    public string displayName = "Default name";
    public virtual string GetDesctiption() { return "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque vel sapien tincidunt, malesuada erat at, semper nisi. Fusce sit amet dolor nec velit luctus"; }
    public virtual void OnStart(SamuraiEffectsManager context) { }
    public virtual void OnAttack(SamuraiEffectsManager context) { }
    public virtual void OnUpdate(SamuraiEffectsManager context, float deltaTime) { }
}
