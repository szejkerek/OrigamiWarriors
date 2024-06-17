using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IUnit
{
    public bool IsAlly => false;

    public Transform attackPoint => throw new System.NotImplementedException();

    public int health = 100; 

    public void TakeDamage(int valueHP)
    {
        Debug.Log("Damaged");
    }

    public void HealUnit(int valueHP)
    {
        throw new System.NotImplementedException();
    }

    public void HealToMax()
    {
        throw new System.NotImplementedException();
    }

    public int GetMaxHealth()
    {
        return health;
    }
}
