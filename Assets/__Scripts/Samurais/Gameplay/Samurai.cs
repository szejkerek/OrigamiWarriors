using System;
using UnityEngine;
using UnityEngine.TextCore.Text;

public abstract class Samurai : MonoBehaviour, IUnit
{
    public bool IsAlly => true;
    public Character Character { get; private set; }

    public Transform AttackPoint => attackPoint;
    [SerializeField] Transform attackPoint;

    SamuraiStylizer samuraiStylizer;
    SamuraiRenderers samuraiRenderer;
    SamuraiEffectsManager samuraiEffectsManager;

    protected abstract void OnSamuraiDeath();

    public void SetCharacterData(Character character)
    {
        this.Character = character;
    }

    protected virtual void Start()
    {
        samuraiStylizer = GetComponent<SamuraiStylizer>();
        samuraiRenderer = GetComponentInChildren<SamuraiRenderers>();
        samuraiEffectsManager = GetComponent<SamuraiEffectsManager>();
        Character.SamuraiVisuals.Apply(samuraiStylizer.Renderers, Character);
        samuraiEffectsManager.Initialize(Character);
    }
    public void UseSkill(IUnit target)
    {
        Character.Skill.itemData.Use(target, this);
    }

    public void TakeDamage(int valueHP)
    {
        CharacterStats stats = Character.GetStats();
        int damageReducedByArmor = Mathf.Max(0, valueHP - stats.Armor);
        Character.LostHealth += damageReducedByArmor;

        if (stats.MaxHealth <= Character.LostHealth)
        {
            OnSamuraiDeath();
        }
        Debug.Log($"{name} took {damageReducedByArmor} damage ({valueHP} - {stats.Armor})");

        samuraiRenderer.SetDamagePercent((float)Character.LostHealth/ (float)stats.MaxHealth);

        Character.OnHealthChange?.Invoke();

    }



    public void HealUnit(int valueHP)
    {
        Character.LostHealth -= valueHP;
        if (Character.LostHealth < 0)
        {
            Character.LostHealth = 0;
            Debug.Log("I'm full healed");
        }
        Character.OnHealthChange?.Invoke();
    }

    public void HealToMax()
    {
        Character.LostHealth = 0;
        Character.OnHealthChange?.Invoke();
    }

    public CharacterStats GetStats()
    {
        return Character.GetStats();
    }

    public void AttackTarget(IUnit target)
    {
        Character.Weapon.itemData.Use(target, this);
    }
}
