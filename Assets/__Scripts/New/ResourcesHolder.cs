using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ResourcesHolder
{
    public static Action OnResourcesUpdated;

    public int Money {  get; private set; }
    private int money = 0;
    public int Expirience {  get; private set; }
    private int expirience = 0; 

    public void AddMoney(int money)
    {
        OnResourcesUpdated?.Invoke();
    }

    public void RemoveMoney(int money)
    {
        OnResourcesUpdated?.Invoke();
    }
    public void AddExpirience(int exp)
    {
        OnResourcesUpdated?.Invoke();
    }

    public void RemoveExpirience(int exp)
    {
        OnResourcesUpdated?.Invoke();
    }

}
