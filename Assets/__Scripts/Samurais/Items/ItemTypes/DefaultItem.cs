using UnityEngine;

[CreateAssetMenu(fileName = "NewDefault", menuName = "Character/Items/Default", order = 1)]
public class DefaultItem : ItemSO
{
    public override void Execute(IUnit target, IUnit origin)
    {
        Debug.Log("Execute");
    }
}
