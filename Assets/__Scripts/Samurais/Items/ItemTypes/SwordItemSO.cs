using UnityEngine;

[CreateAssetMenu(fileName = "NewSword", menuName = "Character/Items/Sword", order = 1)]
public class SwordItemSO : ItemSO
{
    [field: Header("Sword")]
    [field: SerializeField] public float Range { get; private set; }
    [field: SerializeField] public GameObject HitParticle { get; private set; }
    [field: SerializeField] public AnimationClip swordAnimation { get; private set; }

    public override void Use(IUnit target, IUnit origin)
    {
        if (!Cooldown.IsOffCooldown())
            return;

        if (!UnitInRange(target, origin, Range))
            return;

        SpawnParticle(origin.AttackPoint.position);
        target.TakeDamage(origin.CalculateDamage());
        Cooldown.ResetTimers();

    }

    private void SpawnParticle(Vector3 position)
    {
        var particle = Instantiate(HitParticle, position, Quaternion.identity);
        Destroy(particle, 0.3f);
    }
}
