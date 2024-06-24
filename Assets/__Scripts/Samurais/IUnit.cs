using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUnit
{
    Action OnAttack { get; set; }
    GameObject gameObject { get; }
    Transform AttackPoint { get; }
    bool IsAlly { get; }
    void TakeDamage(int valueHP);
    int CalculateDamage()
    {
        int damage = GetStats().Damage;
        if(UnityEngine.Random.Range(0f, 1f) <= GetStats().CritChance)
        {
            damage = damage * 2;
        }
        return damage;
    }
    void HealUnit(int valueHP);
    void HealToMax();
    void AttackTarget(IUnit target);
    CharacterStats GetStats();
}
