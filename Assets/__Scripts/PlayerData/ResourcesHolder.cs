using System;
using Unity.VisualScripting;

[Serializable]
public class ResourcesHolder
{
    public static Action<ResourcesHolder> OnResourcesUpdated;
    public int Money;

    public void AddMoney(int money)
    {
        Money += money;
        OnResourcesUpdated?.Invoke(this);
    }

    public bool TryRemoveMoney(int money)
    {
        money = Math.Abs(money);
        if (Money - money < 0) 
            return false; 

        Money -= money;
        OnResourcesUpdated?.Invoke(this);
        return true;
    }
}
