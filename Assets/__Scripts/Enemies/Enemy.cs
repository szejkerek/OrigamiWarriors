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
    public Action<Enemy> OnDamaged;

    private EnemyGenerator generator;
    public bool IsAlly => false;
    public CharacterStats CharacterStats;
    public int moneyOnKill = 50;

    public Transform AttackPoint => attackPoint;

    public Action OnAttack { get; set; }

    [SerializeField] Transform attackPoint;

    public int Health { get; private set; }

    public ParticleSystem particles;


    private void Awake()
    {
        generator = GetComponent<EnemyGenerator>();
        GetComponent<NavMeshAgent>().speed = CharacterStats.Speed;
        weaponItem = new Item(Weapon.AssetGUID);
        Health = GetStats().MaxHealth;
        GetComponentInChildren<HealthBarEnemy>().Init(this);
    }

    public void TakeDamage(int valueHP)
    {
        int damageReducedByArmor = Mathf.Max(0, valueHP - CharacterStats.Armor);
        Health -= damageReducedByArmor;
        Debug.Log($"{name} took {damageReducedByArmor} damage ({valueHP} - {CharacterStats.Armor})");
        if(Health < 0)
        {
            OnEnemyKilled?.Invoke(this);
            Destroy(gameObject);
        }
        else
        {
            generator.GetDamage((float)Health/ (float)GetStats().MaxHealth);
        }
        OnDamaged?.Invoke(this);    
    }
    public void HealUnit(int valueHP)
    {
        Health = Mathf.Min(Health + valueHP, GetStats().MaxHealth);
    }

    public void HealToMax()
    {
        Health = GetStats().MaxHealth;
    }

    public CharacterStats GetStats()
    {
        return CharacterStats + weaponItem.GetStats();
    }

    public void AttackTarget(IUnit target)
    {
        OnAttack?.Invoke();
        weaponItem.itemData.Use(target, this);
    }

    private void OnDestroy()
    {
        if(particles != null)
        {
            particles.emissionRate = 0;
            Destroy(particles.GetComponent<EnemyParticle>(), 5);
            Destroy(particles, 15);
        }
    }
}
