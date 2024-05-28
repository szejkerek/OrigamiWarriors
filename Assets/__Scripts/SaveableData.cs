using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveableData 
{
    public ResourcesHolder playerResources;
    public LevelResults levelResults = null;
    public Team team;

    public SaveableData(TeamSO startingTeam)
    {
        team = new Team(startingTeam);
        playerResources = new ResourcesHolder();
    }
}
