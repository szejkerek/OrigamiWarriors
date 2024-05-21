using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public string displayName { get; private set; }
    public Sprite icon { get; private set; }
    public CharacterClass characterClass { get; private set; }

    public Item(string displayName, Sprite icon, CharacterClass characterClass)
    {
        this.displayName = displayName;
        this.icon = icon;
        this.characterClass = characterClass;
    }
}

public class ThrowableItem : Item, IExecutable
{
    public float throwPower { get; private set; }
    public ThrowableItem(ThrowableItemSO data) : this (data.DisplayName, data.Icon, data.CharacterClass, data.ThrowPower) {}

    public ThrowableItem(string displayName, Sprite icon, CharacterClass characterClass, float throwPower) : base(displayName, icon, characterClass)
    {
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
    [field: SerializeField] public CharacterClass CharacterClass { private set; get; }
}

[System.Serializable]
public enum CharacterClass
{
    ALL,
    MELEE,
    RANGED,
    MAGE
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

[CreateAssetMenu(fileName = "NewPassiveItem", menuName = "CharacterCreator/Items/Passive")]
public class PassiveItemSO : ItemSO
{
    [field: SerializeField] public float Damage { private set; get; }
}

[CreateAssetMenu(fileName = "NewEffectItem", menuName = "CharacterCreator/Items/Effect")]
public class EffectItemSO : ItemSO
{
    [field: SerializeField] public float Power { private set; get; }
}