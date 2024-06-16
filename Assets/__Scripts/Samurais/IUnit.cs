using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUnit
{
    bool IsAlly { get; }
    void TakeDamage(int valueHP);
    void HealUnit(int valueHP);
    void HealToMax();

    int GetMaxHealth();
}
