using UnityEngine;

[CreateAssetMenu]
public class PassiveHealingEffect : PassiveEffect
{
    public float healthPerTick;
    public float range;

    public override void OnUpdate(SamuraiEffectsManager context, float deltaTime)
    {
        foreach (var team in context.Team)
        {
            if(Vector3.Distance(context.transform.position, team.transform.position) <= range)
            {
                Debug.Log($"{team.name} was healed for {healthPerTick}");
            }
        }
    }
}