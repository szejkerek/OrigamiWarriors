using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Character/Passsives/Bogacz")]
public class PassiveBogacz : PassiveEffectSO
{
    public float bonusDamagePerGold;
    public override string GetDesctiption()
    {
        return $"zadaje dodatkowe obra¿enia zalezne od liczby z³ota";
    }

    public override string GetName()
    {
        return "Bogacz";
    }

    public override void OnStart(SamuraiEffectsManager context)
    {
        context.Owner.temporaryStats.Damage += (int)((float)SavableDataManager.Instance.data.playerResources.Money * bonusDamagePerGold);
    }

    public override void OnAttack(SamuraiEffectsManager context, IUnit target)
    {
        //TODO: Particle of coins in attack animation
    }

}
