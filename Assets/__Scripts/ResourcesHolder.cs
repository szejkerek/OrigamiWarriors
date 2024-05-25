using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ResourcesHolder
{
    public static Action OnResourcesUpdated;
    public int Money {  get; private set; }
    public int Expirience {  get; private set; }

    public void AddMoney(int money)
    {
        Money += money;
        OnResourcesUpdated?.Invoke();
    }

    public bool TryRemoveMoney(int money)
    {
        if (Money - money < 0) 
            return false; 

        Money -= money;
        OnResourcesUpdated?.Invoke();
        return true;
    }
    public void AddExpirience(int exp)
    {
        Expirience += exp;
        OnResourcesUpdated?.Invoke();
    }

}
