using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IUnit
{
    public ItemSO Weapon;
    public static Action<Enemy> OnEnemyKilled;
    public bool IsAlly => false;
    public CharacterStats CharacterStats;
    public int moneyOnKill = 50;

    public Transform AttackPoint => throw new System.NotImplementedException();

    private int health;

    private void Awake()
    {
        health = GetStats().MaxHealth;
        GetComponent<NavMeshAgent>().speed = CharacterStats.Speed;

    }

    public void TakeDamage(int valueHP)
    {
        int damageReducedByArmor = Mathf.Max(0, valueHP - CharacterStats.Armor);
        health -= damageReducedByArmor;
        Debug.Log($"{name} took {damageReducedByArmor} damage ({valueHP} - {CharacterStats.Armor})");
        if(health < 0)
        {
            OnEnemyKilled?.Invoke(this);
            Destroy(gameObject);
        }
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

    public void AttackTarget(IUnit target)
    {
        Weapon.Use(target, this);
    }
}
