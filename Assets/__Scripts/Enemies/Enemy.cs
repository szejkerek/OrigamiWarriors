using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IUnit
{
    public AssetReferenceItemSO Weapon;
    private Item weaponItem;


    public static Action<Enemy> OnEnemyKilled;
    public bool IsAlly => false;
    public CharacterStats CharacterStats;
    public int moneyOnKill = 50;

    public Transform AttackPoint => attackPoint;
    [SerializeField] Transform attackPoint;

    private int health;

    public GameObject particles;

    private void Awake()
    {
        GetComponent<NavMeshAgent>().speed = CharacterStats.Speed;
        weaponItem = new Item(Weapon.AssetGUID);
        health = GetStats().MaxHealth;
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
        return CharacterStats + weaponItem.GetStats();
    }

    public void AttackTarget(IUnit target)
    {
        weaponItem.itemData.Use(target, this);
    }

    private void OnDestroy()
    {
        particles.GetComponent<ParticleSystem>().emissionRate = 0;
        Destroy(particles, 15);
    }
}
