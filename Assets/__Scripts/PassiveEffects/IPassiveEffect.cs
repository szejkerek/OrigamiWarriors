public interface IPassiveEffect
{
    public void OnStart(SamuraiEffectsManager context);
    public void OnAttack(SamuraiEffectsManager context);
    public void OnUpdate(SamuraiEffectsManager context, float deltaTime);
}
