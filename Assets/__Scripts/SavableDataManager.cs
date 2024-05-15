using GordonEssentials;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GeneralData
{
    public int money = 0;
}
public class SavableDataManager : Singleton<SavableDataManager>
{
    public GeneralData data;

    protected override void Awake()
    {
        base.Awake();
        //load variables from file etc.
    }


}
