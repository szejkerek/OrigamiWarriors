using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemyAgent : GoapAgent
{
    protected override void SetupBeliefs()
    {
        base.SetupBeliefs();
    }

    protected override void SetupActions()
    {
        base.SetupActions();

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

        
    }
}
