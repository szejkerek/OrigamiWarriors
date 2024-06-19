using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SamuraiEffectsManager : MonoBehaviour
{
    List<IPassiveEffect> effectsList = new List<IPassiveEffect>();

    public List<Samurai> Team;
    public List<GameObject> Enemies;


    public void Initialize(Character character)
    {
        GatherPassives(character);
        GatherMapUnits();

        effectsList.ForEach(e => e.OnStart(this));
    }

    private void OnEnable()
    {
        SamuraiAlly.OnDeath += GatherMapUnits;
    }

    private void GatherMapUnits(Samurai samurai = null)
    {
        Team = FindObjectsOfType<Samurai>().ToList();
    }

    private void OnDisable()
    {
        SamuraiAlly.OnDeath -= GatherMapUnits;
    }

    private void GatherPassives(Character character)
    {
        effectsList.Add(character.Weapon.itemData);
        effectsList.Add(character.Armor.itemData);
        effectsList.Add(character.Skill.itemData);
        character.PassiveEffects.ForEach(e => effectsList.Add(e));
    }

    private void Update()
    {
        effectsList.ForEach(e => e.OnUpdate(this, Time.deltaTime));
    }
}


public interface IPassiveEffect
{
    public void OnStart(SamuraiEffectsManager context);
    public void OnUpdate(SamuraiEffectsManager context, float deltaTime);
}
