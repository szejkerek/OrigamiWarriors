using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealth
{
    void Damage(int valueHP);
    void Heal(int valueHP);
    void HealToFull();
}
