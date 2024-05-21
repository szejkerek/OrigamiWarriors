using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveableData 
{
    public ResourcesHolder playerResurces;
    public List<Character> characters = new List<Character>();
}
