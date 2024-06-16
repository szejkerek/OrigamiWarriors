using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IUnit
{
  
    public void Damage(int valueHP)
    {
        Debug.Log("Damaged");
    }

    public void Heal(int valueHP)
    {
        throw new System.NotImplementedException();
    }

    public void HealToFull()
    {
        throw new System.NotImplementedException();
    }
}
