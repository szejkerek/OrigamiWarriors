using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;



public class StatusManager : MonoBehaviour
{
    bool isWeakenessApplied = false;
    int weaknessValue = 0;

    bool isPoisonApplied = false;
    float timeToTick = 0.5f;
    public void ApplyStun(float timer)
    {
        StartCoroutine(ApplyStunCorutine(timer));
    }
    IEnumerator ApplyStunCorutine(float timer)
    {
        Debug.Log("Stunned");
        yield return null;
    }
    public void RevertStun()
    {

    }
    public void ApplyWeakness(float timer, float weaknessRatio)
    {
        StartCoroutine(ApplyWeaknessCorutine(timer, weaknessRatio));
    }
    IEnumerator ApplyWeaknessCorutine(float timer, float weaknessRatio)
    {
        ApplyWeakness(weaknessRatio);
        yield return new WaitForSeconds(timer);
        RevertWeakness();
    }
    public void ApplyWeakness(float weaknessRatio)
    {
        isWeakenessApplied = true;
        IUnit unit = GetComponent<IUnit>();
        weaknessValue = (int)((float)unit.GetStats().Damage * weaknessRatio);
        WeaknessEffect(isWeakenessApplied);
    }
    public void RevertWeakness()
    {
        isWeakenessApplied = false;
        WeaknessEffect(isWeakenessApplied);
        weaknessValue = 0;
    }

    public void ApplyPoison(float dmgPerTick, int ticks)
    {
        StartCoroutine(ApplyPoisonCorutine(dmgPerTick, ticks));
    }
    IEnumerator ApplyPoisonCorutine(float dmgPerTick, int ticks)
    {
        isPoisonApplied = true;
        int appliedTicks = 0;
        Debug.Log("Poisoned");
        IUnit unit = GetComponent<IUnit>();
        while (appliedTicks < ticks)
        {
            if(isPoisonApplied)unit.TakeDamage((int)dmgPerTick);
            yield return new WaitForSeconds(timeToTick);
            appliedTicks++;
        }
        isPoisonApplied = false;
    }

    public void RevertPoison()
    {
        isPoisonApplied = false;
    }

    public void ApplyCleanse()
    {
        RevertStun();
        RevertWeakness();
        RevertPoison();
        StopAllCoroutines();
    }

    public void WeaknessEffect(bool apply)
    {
        CharacterStats stats = new CharacterStats();
        stats.Damage = weaknessValue;
        stats.Damage *= ((apply) ? -1 : 1);

        if (TryGetComponent<Samurai>(out Samurai samurai))
        {
            samurai.temporaryStats += stats;
        }
        if (TryGetComponent<Enemy>(out Enemy enemy))
        {
            enemy.temporaryStats += stats;
        }

    }
}
