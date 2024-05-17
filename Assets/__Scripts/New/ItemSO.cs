using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableItem : IExecutable
{
    public string displayName { get; private set; }
    public Sprite icon { get; private set; }
    public float throwPower { get; private set; }
    public ThrowableItem(ThrowableItemSO data)
    {
        displayName = data.DisplayName;
        icon = data.Icon;
        throwPower = data.ThrowPower;
    }

    public ThrowableItem(string displayName,Sprite icon,float throwPower)
    {
        this.displayName = displayName;
        this.icon = icon;
        this.throwPower = throwPower;
    }

    public void Execute()
    {
        Debug.Log($"{displayName} is thrown with power {throwPower}!");
    }
}

public interface IExecutable
{
    void Execute();
}

public class ItemSO : ScriptableObject
{
    [field: SerializeField] public string DisplayName { private set; get; }
    [field: SerializeField] public Sprite Icon { private set; get; }
}

[CreateAssetMenu(fileName = "NewThrowableItem", menuName = "CharacterCreator/Items/Throwable")]
public class ThrowableItemSO : ItemSO
{
    [field: SerializeField] public float ThrowPower { private set; get; }
}

[CreateAssetMenu(fileName = "NewMeleeItem", menuName = "CharacterCreator/Items/Melee")]
public class MeleeItemSO : ItemSO
{
    [field: SerializeField] public float Damage { private set; get; }
}

[CreateAssetMenu(fileName = "NewAoEItem", menuName = "CharacterCreator/Items/AoE")]
public class AoEItemSO : ItemSO
{
    [field: SerializeField] public float Range { private set; get; }
}

[CreateAssetMenu(fileName = "NewPassivetem", menuName = "CharacterCreator/Items/Passive")]
public class PassiveItemSO : ItemSO
{
    [field: SerializeField] public float Damage { private set; get; }
}

[CreateAssetMenu(fileName = "NewEffecttem", menuName = "CharacterCreator/Items/Effect")]
public class EffectItemSO : ItemSO
{
    [field: SerializeField] public float Power { private set; get; }
}