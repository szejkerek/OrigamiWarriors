using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AllyAgent : GoapAgent
{
    public AllyAgent(Transform player)
    {
        playerPosition = player;
    }


    private Transform playerPosition;

    //private enum  = false;

    protected override void Start()
    {
        base.Start();
    }
    protected override void Update()
    {
      // ONLY DISPLAY COMMANDS: attack stay follow scout
      base.Update();
      if (Input.GetKeyUp("1")){
        //AttackCommand
        OnAttack(null);
      //Debug.Log("AttackCommand");
      }
      //if (Input.GetKeyUp("2")){
      //  //DefenseCommand
      //  OnDefense(null);
      ////Debug.Log("DefenseCommand");
      //}
      //if (Input.GetKeyUp("3")){
      //  //AttackBigCommand
      //  AttackStrongCommand(null);
      ////Debug.Log("AttackBigCommand");
      //}
      //if (Input.GetKeyUp("4")){
      //  //AttackSmallCommand
      //  AttackWeakCommand(null);
      ////Debug.Log("AttackSmallCommand");
      //}
      if (Input.GetKeyUp("4")){
        //MarchWanderCommand
        WanderCommand(null);
      //Debug.Log("MarchWanderCommand");
      }
      if (Input.GetKeyUp("3")){
        //FollowSupportCommand
        FollowCommand(null);
      //Debug.Log("FollowSupportCommand");
      }
      if (Input.GetKeyUp("2")){
        //StayIdleCommand
        StayCommand(null);
      //Debug.Log("StayIdleCommand");
      }
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
            .WithStrategy(new AttackStrategy(1, attackSensor, 10, animator, this))
            .AddPrecondition(beliefs["EnemyInAttackRange"])
            .AddEffect(beliefs["AttackingEnemy"])
            .Build());

        
    }

    protected override void SetupGoals()
    {
        base.SetupGoals();

        AttackCommand.OnAttackRecognized += OnAttack; // Kogeki (Kougeki) - Attack
        //DefenseCommand.OnDefenseRecognized += OnDefense; // Mamoru - Defend
        //AttackBigCommand.OnAttackBigRecognized += AttackStrongCommand; // bigu -> attack big (max health enemy)
        //AttackSmallCommand.OnAttackSmallRecognized += AttackWeakCommand; // smalu -> attack small (min health enemy)
        MarchWanderCommand.onWanderRecognized += WanderCommand; // Gyoko (Gyoukou) - March
        FollowSupportCommand.onFollowRecognized += FollowCommand; // Hojo - Support
        StayIdleCommand.OnIdleBigRecognized += StayCommand; // Tome - Stop

    //goals.Add(new AgentGoal.Builder("Keep Watch")
    //    .WithPriority(2)
    //    .WithDesiredEffect(beliefs["Nothing"])
    //    .Build());

  }
    private void OnDefense(DefenseCommand command) // Mamoru - Defend
    {
        DefensiveStanceCommand();
    }

    private void OnAttack(AttackCommand command) // Kogeki (Kougeki) - Attack
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
    private void AttackWeakCommand(AttackSmallCommand command) // Kogeki chisai (Kougeki chiisaii) / Kogeki sumoru -> attack small (min health enemy)
  {
      SetupSensors(Sensor.TargetingMode.Weakest);
    }
    private void AttackStrongCommand(AttackBigCommand command) // Kogeki Oki (Kougeki ookii) / Kogeki biggu -> attack big (max health enemy)
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
  public void WanderCommand(MarchWanderCommand command) // Gyoko (Gyoukou) - March
  {
        Debug.Log("SCOUT!");
        if (CommadExists("GroupUp"))
        {
            goals.Remove(GetGoal("GroupUp"));
        }


        if (!CommadExists("Wander"))
        {
            goals.Add(new AgentGoal.Builder("Wander")
            .WithPriority(1)
            .WithDesiredEffect(beliefs["AgentMoving"])
            .Build());

        }
    }
    public void StayCommand(StayIdleCommand command) // Tome - Stop
  {

        Debug.Log("STAY!");
        if(CommadExists("GroupUp"))
        {
            goals.Remove(GetGoal("GroupUp"));
        }
        if (CommadExists("Wander"))
        {
            goals.Remove(GetGoal("Wander"));
        }
    }
    public void FollowCommand(FollowSupportCommand command) // Hojo (Hojou) - Support
    {
        Debug.Log("FOLLOW!");
        if (CommadExists("Wander"))
        {
            goals.Remove(GetGoal("Wander"));
        }

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
