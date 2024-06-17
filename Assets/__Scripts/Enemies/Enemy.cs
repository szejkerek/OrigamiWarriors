using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IUnit
{
    public bool IsAlly => false;
    public CharacterStats CharacterStats;

    public Transform AttackPoint => throw new System.NotImplementedException();

    private int health;

    private void Awake()
    {
        health = GetStats().MaxHealth;
    }

    public void TakeDamage(int valueHP)
    {
        health -= valueHP;
        if(health < 0)
        {
            Destroy(gameObject);
        }
        Debug.Log("Damaged");
    }

    public void HealUnit(int valueHP)
    {
        health = Mathf.Min(health + valueHP, GetStats().MaxHealth);
    }

    public void HealToMax()
    {
        health = GetStats().MaxHealth;
    }

    public CharacterStats GetStats()
    {
        return CharacterStats;
    }
}
