using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

[CreateAssetMenu(menuName = "Character/Passsives/ShamanDebuffAOE")]
public class PassiveShamanDebuffAOE : PassiveEffectSO
{
    public float damageDebuff;
    public float range;
    public List<KeyValuePair<Enemy, int>> affectedEnemies = new List<KeyValuePair<Enemy, int>>();

    public override string GetDesctiption()
    {
        return $"zmniejsza atak pobliskich przeciwników o {damageDebuff * 100:0} %";
    }

    public override string GetName()
    {
        return "Shaman";
    }

    public override void OnUpdate(SamuraiEffectsManager context, float deltaTime)
    {
        if (affectedEnemies != null)
        {
            foreach (KeyValuePair<Enemy, int> effet in affectedEnemies)
            {
                effet.Key.temporaryStats.Damage -= effet.Value;
            }
            affectedEnemies.Clear();
        }


        foreach (Enemy enemy in context.Enemies)
        {
            if (enemy == null)
                return;

            if (Vector3.Distance(context.transform.position, enemy.transform.position) <= range)
            {
                int debuffValue = -(int)math.ceil(enemy.GetStats().Damage * damageDebuff);
                enemy.temporaryStats.Damage += debuffValue;
                affectedEnemies.Add(new KeyValuePair<Enemy, int>(enemy, debuffValue));
            }
        }
    }
}
