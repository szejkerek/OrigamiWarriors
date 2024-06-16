using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyAgent : GoapAgent
{
    public AllyAgent(Transform player)
    {
        playerPosition = player;
    }


    private Transform playerPosition;

    private bool isWandering = false;
    //private enum  = false;

    protected override void Start()
    {
        base.Start();
    }

    protected override void SetupBeliefs()
    {
        base.SetupBeliefs();
        
        BeliefFactory factory = new BeliefFactory(this, beliefs);
        Debug.Log(FindAnyObjectByType<GameplayTeamManagement>().general.name);
        factory.AddLocationBelief("NearPlayer", 3f, FindAnyObjectByType<GameplayTeamManagement>().general.transform);
    }

    protected override void SetupActions()
    {
        base.SetupActions();
        
        actions.Add(new AgentAction.Builder("MoveToPlayer")
        .WithStrategy(new MoveStrategy(navMeshAgent, () => 
        playerPosition != null ? playerPosition.transform.position : GameObject.FindGameObjectWithTag("Player").transform.position))
        .AddEffect(beliefs["NearPlayer"])
        .Build());

        actions.Add(new AgentAction.Builder("LoadAttack")
            .WithStrategy(new LoadAttackStrategy(1))
            .AddPrecondition(beliefs["EnemyInAttackRange"])
            .AddEffect(beliefs["AttackLoaded"])
            .Build());

        actions.Add(new AgentAction.Builder("AttackEnemy")
            .WithStrategy(new AttackStrategy(1))
            .AddPrecondition(beliefs["EnemyInAttackRange"])
            .AddPrecondition(beliefs["AttackLoaded"])
            .AddEffect(beliefs["AttackingEnemy"])
            .Build());

        
    }

    protected override void SetupGoals()
    {
        base.SetupGoals();

        goals.Add(new AgentGoal.Builder("GroupUp")
            .WithPriority(3)
            .WithDesiredEffect(beliefs["NearPlayer"])
            .Build());

        //goals.Add(new AgentGoal.Builder("Keep Watch")
        //    .WithPriority(2)
        //    .WithDesiredEffect(beliefs["Nothing"])
        //    .Build());

    }
}
