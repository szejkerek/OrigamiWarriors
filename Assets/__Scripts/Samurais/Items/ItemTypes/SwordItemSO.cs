using UnityEngine;

[CreateAssetMenu(fileName = "NewSword", menuName = "Character/Items/Sword", order = 1)]
public class SwordItemSO : ItemSO
{
    [field: Header("Sword")]
    [field: SerializeField] public float Range { get; private set; }

    public override void Execute()
    {
        Debug.Log("Execute");
    }
}
