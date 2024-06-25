using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

[CreateAssetMenu(menuName = "Character/Passsives/ShamanDebuffAOE")]
public class PassiveShamanDebuffAOE : PassiveEffectSO
{
    public float damageDebuff;
    public float range;
    public List<Enemy> affectedEnemies = new List<Enemy>();

    public override string GetDesctiption()
    {
        return $"zmniejsza atak pobliskich przeciwników o {damageDebuff * 100:0} %";
    }

    public override string GetName()
    {
        return "Shaman";
    }

    public override void OnStart(SamuraiEffectsManager context)
    {
        affectedEnemies.Clear();
    }

    public override void OnUpdate(SamuraiEffectsManager context, float deltaTime)
    {
        if(affectedEnemies != null)
        {
            foreach(Enemy enemy in affectedEnemies)
            {
                if(enemy != null)enemy.GetComponent<StatusManager>().RevertWeakness();
            }
            affectedEnemies.Clear();
        }
        

        foreach (Enemy enemy in context.Enemies)
        {
            if (enemy == null)
                return;
            
            if (Vector3.Distance(context.transform.position, enemy.transform.position) <= range)
            {
                affectedEnemies.Add(enemy);
                enemy.GetComponent<StatusManager>().ApplyWeakness(damageDebuff);
            }
        }
    }
}
