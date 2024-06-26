using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Character/Passsives/Truciciel")]
public class PassiveTruciciel : PassiveEffectSO
{
    public int dmgPerTick;
    public int ticks;
    public override string GetDesctiption()
    {
        return $"ataki nak³adaj¹ truciznê, zadaj¹ca celowi obra¿enie co sekundê";
    }

    public override string GetName()
    {
        return "Truciciel";
    }

    public override void OnAttack(SamuraiEffectsManager context, IUnit target)
    {
        //TODO: Particle of coins in attack animation
        target.gameObject.GetComponent<StatusManager>().ApplyPoison(dmgPerTick, ticks);
    }

}
