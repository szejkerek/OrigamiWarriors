using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class StatusManager : MonoBehaviour
{
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
        Debug.Log("Weakened");
        yield return null;
    }

    public void RevertWeakness()
    {

    }

    public void ApplyPoison(float dmgPerTick, int ticks)
    {
        StartCoroutine(ApplyWeaknessCorutine(dmgPerTick, ticks));
    }
    IEnumerator ApplyPoisonCorutine(float dmgPerTick, int ticks)
    {
        Debug.Log("Poisoned");
        yield return null;
    }

    public void RevertPoison()
    {

    }

    public void ApplyCleanse()
    {
        RevertStun();
        RevertWeakness();
        RevertPoison();
        StopAllCoroutines();
    }
}
