using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewTeam", menuName = "Character/Team", order = 0)]
public class TeamSO : ScriptableObject
{

    [field: SerializeField] public AssetReferenceCharacterSO General { private set; get; }
    [field: SerializeField] public List<AssetReferenceCharacterSO> TeamMembers { private set; get; }

}

[Serializable]
public class Team
{
    public Character General;
    public List<Character> TeamMembers;

    public Team(TeamSO team)
    {
        General = new Character(team.General.AssetGUID);
        TeamMembers = new List<Character>();

        foreach (var member in team.TeamMembers)
        {
            TeamMembers.Add(new Character(member.AssetGUID));
        }
    }

    public Team(Character General, List<Character> TeamMembers)
    {
        this.General = General;
        this.TeamMembers = TeamMembers;
    }

    public void KillCharacter(Character character)
    {
        TeamMembers.Remove(character);
    }
}