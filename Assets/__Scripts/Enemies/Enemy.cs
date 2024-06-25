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

    private EnemyGenerator generator;
    public bool IsAlly => false;
    public CharacterStats CharacterStats;
    public int moneyOnKill = 50;

    public Transform AttackPoint => attackPoint;

    public Action OnAttack { get; set; }

    [SerializeField] Transform attackPoint;

    private int health;

    public ParticleSystem particles;

    SamuraiGeneral general;

    private void Awake()
    {
        generator = GetComponent<EnemyGenerator>();
        GetComponent<NavMeshAgent>().speed = CharacterStats.Speed;
        weaponItem = new Item(Weapon.AssetGUID);
        health = GetStats().MaxHealth;
        general = FindObjectOfType<SamuraiGeneral>();
    }
    //private void OnMouseOver()
    //{
    //    Debug.Log("Over");
    //    if (Vector3.Distance(general.transform.position, transform.position) <= general.Character.Weapon.itemData.Range)
    //    {
    //        CursorManager.Instance.SetCursorState(CursorState.Attack);
    //    }
    //    else
    //    {
    //        CursorManager.Instance.SetCursorState(CursorState.Default);
    //    }
    //}

    //private void OnMouseExit()
    //{
    //    Debug.Log("Exit");
    //    CursorManager.Instance.SetCursorState(CursorState.Default);
    //}

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
        else
        {
            generator.GetDamage((float)health/ (float)GetStats().MaxHealth);
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
