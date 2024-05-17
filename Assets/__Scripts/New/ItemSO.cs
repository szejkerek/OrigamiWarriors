using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class ItemSO : ScriptableObject, IUseable
{
    [field: SerializeField] public string DisplayName { private set; get; }
    [field: SerializeField] public Sprite Icon { private set; get; }
    public abstract void Execute();
}

internal interface IUseable
{
    void Execute();
}

[CreateAssetMenu(fileName = "NewItem", menuName = "CharacterCreator/Items/Throwable")]
public class ThrowableItemSO : ItemSO
{
    public override void Execute()
    {
        throw new System.NotImplementedException();
    }
}

