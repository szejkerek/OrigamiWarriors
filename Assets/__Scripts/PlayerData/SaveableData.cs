using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveableData
{
    public ResourcesHolder playerResources = new ResourcesHolder();
    public LevelResults levelResults = new();
    public Team team;
    public Map map = new();
}
