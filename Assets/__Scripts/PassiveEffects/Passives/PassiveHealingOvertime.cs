﻿using Tayx.Graphy.Utils.NumString;
using UnityEngine;

[CreateAssetMenu(menuName = "Character/Passsives/HealingOvertime")]
public class PassiveHealingOvertime : PassiveEffectSO
{
    public float healthPerTick;
    public float range;

    public override string GetDesctiption()
    {
        return $"leczy pobliskie jednostki o {healthPerTick}";
    }

    public override string GetName()
    {
        return "Lekarz";
    }

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
