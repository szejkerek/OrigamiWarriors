using Tayx.Graphy.Utils.NumString;
using UnityEngine;

[CreateAssetMenu]
public class PassiveHealingEffect : PassiveEffectSO
{
    public float healthPerTick;
    public float range;

    public override void OnUpdate(SamuraiEffectsManager context, float deltaTime)
    {
        foreach (Samurai team in context.Team)
        {
            if (team == null)
                return;

            if(Vector3.Distance(context.transform.position, team.transform.position) <= range)
            {               
                team.HealUnit(healthPerTick.ToInt());
            }
        }
    }
}