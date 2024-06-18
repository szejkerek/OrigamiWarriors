using System;
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
        factory.AddLocationBelief("NearPlayer", 3f, FindAnyObjectByType<GameplayTeamManagement>().general.transform);
    }

    protected override void SetupActions()
    {
        base.SetupActions();
        
        actions.Add(new AgentAction.Builder("MoveToPlayer")
        .WithStrategy(new MoveStrategy(navMeshAgent, () => 
        playerPosition != null ? playerPosition.transform.position : GameObject.FindGameObjectWithTag("Player").transform.position, animator))
        .AddEffect(beliefs["NearPlayer"])
        .Build());


        actions.Add(new AgentAction.Builder("AttackEnemy")
            .WithStrategy(new AttackStrategy(1, attackSensor, 10, animator))
            .AddPrecondition(beliefs["EnemyInAttackRange"])
            .AddEffect(beliefs["AttackingEnemy"])
            .Build());

        
    }

    protected override void SetupGoals()
    {
        base.SetupGoals();

        AttackCommand.OnAttackRecognized += OnAttack;
        AttackCommand.OnAttackRecognized += OnDefense;

        //goals.Add(new AgentGoal.Builder("Keep Watch")
        //    .WithPriority(2)
        //    .WithDesiredEffect(beliefs["Nothing"])
        //    .Build());

    }

    private void OnDefense(AttackCommand command)
    {
        DefensiveStanceCommand();
    }

    private void OnAttack(AttackCommand command)
    {
        AttackNormalCommand();
    }

    public void AggressiveStanceCommand()
    {

    }

    public void DefensiveStanceCommand()
    {

    }
    public void NormalStanceCommand()
    {

    }
    public void AttackWeakCommand()
    {
        SetupSensors(Sensor.TargetingMode.Weakest);
    }
    public void AttackStrongCommand()
    {
        SetupSensors(Sensor.TargetingMode.Strongest);
    }
    public void AttackNormalCommand()
    {
        SetupSensors(Sensor.TargetingMode.Normal);
    }

    private void SetupSensors(Sensor.TargetingMode mode)
    {
        attackSensor.targetingMode = mode;
        chaseSensor.targetingMode = mode;
    }

    public void WanderCommand()
    {
        if (CommadExists("Wander")) return;


        goals.Add(new AgentGoal.Builder("Wander")
            .WithPriority(1)
            .WithDesiredEffect(beliefs["AgentMoving"])
            .Build());
    }
    public void StayCommand()
    {
        if(CommadExists("GroupUp"))
        {
            goals.Remove(GetGoal("GroupUp"));
        }
        if (CommadExists("Wander"))
        {
            goals.Remove(GetGoal("Wander"));
        }
    }
    public void FollowCommand()
    {
        if (CommadExists("GroupUp")) return;


        goals.Add(new AgentGoal.Builder("GroupUp")
            .WithPriority(3)
            .WithDesiredEffect(beliefs["NearPlayer"])
            .Build());
    }

    private bool CommadExists(string name)
    {
        bool exists = false;
        foreach (AgentGoal g in goals)
        {
            if (g.Name == name)
            {
                exists = true;
                break;
            }
        }

        return exists;
    }

    private AgentGoal GetGoal(string name)
    {
        foreach (AgentGoal g in goals)
        {
            if (g.Name == name)
            {
                return g;
            }
        }

        return null;
    }

}
