using UnityEngine;

[CreateAssetMenu(menuName = "Character/Skill/Grzmiący")]
public class SkillGrzmiacy : ItemSO
{
    public float range;
    public override void Use(IUnit target, IUnit origin)
    {
        SamuraiEffectsManager manager = origin.gameObject.GetComponent<SamuraiEffectsManager>();
        if (manager == null)
            return;

        if (!Cooldown.IsCommandOffCooldown())
            return;

        foreach (Enemy enemy in manager.Enemies)
        {
            if (!UnitInRange(origin, enemy, range))
                continue;

            Debug.Log($"{enemy} dostał w łeb z grzmotu");
        }
    }
}
