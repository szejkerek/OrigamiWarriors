using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUnit
{
    void TakeDamage(int valueHP);
    void HealUnit(int valueHP);
    void HealToMax();
}
