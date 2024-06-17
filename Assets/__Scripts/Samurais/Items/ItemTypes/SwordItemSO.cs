using UnityEngine;

[CreateAssetMenu(fileName = "NewSword", menuName = "Character/Items/Sword", order = 1)]
public class SwordItemSO : ItemSO
{
    [field: Header("Sword")]
    [field: SerializeField] public float Range { get; private set; }
    [field: SerializeField] public GameObject HitParticle { get; private set; }
    [field: SerializeField] public AnimationClip swordAnimation { get; private set; }

    public override void Execute(IUnit target, IUnit origin)
    {
        if(UnitInRange(target, origin, Range))
        {
            Debug.Log("Execute sword damage!");
        }
    }
}
