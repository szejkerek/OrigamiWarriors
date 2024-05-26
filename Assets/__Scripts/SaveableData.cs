using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveableData 
{
    public ResourcesHolder playerResources;
    public List<Character> characters = new List<Character>();
}
