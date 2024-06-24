using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SamuraiEffectsManager : MonoBehaviour
{
    List<IPassiveEffect> effectsList = new List<IPassiveEffect>();

    public Samurai Owner;
    public List<Samurai> Team;
    public List<Enemy> Enemies;


    public void Initialize(Character character)
    {
        GatherPassives(character);
        GatherMapUnits();

        effectsList.ForEach(e => e.OnStart(this));
    }

    private void OnEnable()
    {
        Enemy.OnEnemyKilled += (enemy) => GatherMapUnits();
        SamuraiAlly.OnDeath += (samurai) => GatherMapUnits();
    }

    private void GatherMapUnits()
    {
        Owner = GetComponent<Samurai>();
        Team = FindObjectsOfType<Samurai>().ToList();
        Team.Remove(Owner);

        Enemies = FindObjectsOfType<Enemy>().ToList();
    }

    private void OnDisable()
    {
        Enemy.OnEnemyKilled -= (enemy) => GatherMapUnits();
        SamuraiAlly.OnDeath -= (samurai) => GatherMapUnits();
    }

    private void GatherPassives(Character character)
    {
        character.PassiveEffects.ForEach(e => effectsList.Add(e));
        GetComponent<IUnit>().OnAttack += () => { effectsList.ForEach(e => e.OnAttack(this)); };
    }

    private void Update()
    {
        effectsList.ForEach(e => e.OnUpdate(this, Time.deltaTime));
    }
}
