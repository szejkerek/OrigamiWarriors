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
    [SerializeField] SpriteRenderer iconBack, iconFront;
    [SerializeField] Sprite neutral, go, flee, sword, shield;
    [SerializeField] Color weak, any, strong;

    //private enum  = false;

    protected override void Start()
    {
        base.Start();
    }
    protected override void Update()
    {

      base.Update();
        if (Input.GetKeyUp("1"))
        {
            StayCommand(null);// Tome - Stop
    }
        else if (Input.GetKeyUp("2"))
        {
            FollowCommand(null);// Hojo - Support
    }
        else if(Input.GetKeyUp("3"))
        {
            FleeCommand(null);// Gyoko (Gyoukou) - March
    }
        if (Input.GetKeyUp("4"))
        {
            NormalStanceCommand(null);// Nomaru - Normal (stance)
    }
        else if(Input.GetKeyUp("5"))
        {
            AggressiveStanceCommand(null);// Kogeki (Kougeki) - Attack
    }
        else if(Input.GetKeyUp("6"))
        {
            DefensiveStanceCommand(null);// Mamoru - Defend
    }
        if (Input.GetKeyUp("7"))
        {
            AttackNormalCommand(null);// Tatakau - Fight
    }
        else if(Input.GetKeyUp("8"))
        {
            AttackWeakCommand(null);// smalu -> attack small (min health enemy)
    }
        else if(Input.GetKeyUp("9"))
        {
            AttackStrongCommand(null);// bigu -> attack big (max health enemy)
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

        AttackCommand.OnAttackRecognized += AggressiveStanceCommand; // Kogeki (Kougeki) - Attack
        DefenseCommand.OnDefenseRecognized += DefensiveStanceCommand; // Mamoru - Defend
        AttackBigCommand.OnAttackBigRecognized += AttackStrongCommand; // bigu -> attack big (max health enemy)
        AttackSmallCommand.OnAttackSmallRecognized += AttackWeakCommand; // smalu -> attack small (min health enemy)
        MarchWanderCommand.onWanderRecognized += FleeCommand; // Gyoko (Gyoukou) - March
        FollowSupportCommand.onFollowRecognized += FollowCommand; // Hojo - Support
        StayIdleCommand.OnIdleBigRecognized += StayCommand; // Tome - Stop
        StanceNormalCommand.OnNormalStanceRecognized += NormalStanceCommand;// Nomaru - Normal (stance)
        NormalAttackCommand.OnAttackNormalRecognized += AttackNormalCommand;// Tatakau - Fight / Attack Normal

        StayCommand(null);
        NormalStanceCommand(null);
        AttackNormalCommand(null);

    //goals.Add(new AgentGoal.Builder("Keep Watch")
    //    .WithPriority(2)
    //    .WithDesiredEffect(beliefs["Nothing"])
    //    .Build());

  }




    public void AggressiveStanceCommand(AttackCommand command)
    {
        iconFront.sprite = sword;
    }

    public void DefensiveStanceCommand(DefenseCommand command)
    {
        iconFront.sprite = shield;
    }
    public void NormalStanceCommand(StanceNormalCommand command)
    {
        iconFront.sprite = null;
    }
    public void AttackWeakCommand(AttackSmallCommand command) // Kogeki chisai (Kougeki chiisaii) / Kogeki sumoru -> attack small (min health enemy)
  {
        iconBack.color = weak;
      SetupSensors(Sensor.TargetingMode.Weakest);
        
    }
    public void AttackStrongCommand(AttackBigCommand command) // Kogeki Oki (Kougeki ookii) / Kogeki biggu -> attack big (max health enemy)
  {
        iconBack.color = strong;
        SetupSensors(Sensor.TargetingMode.Strongest);
    }
    public void AttackNormalCommand(NormalAttackCommand command)
    {
        iconBack.color = any;
        SetupSensors(Sensor.TargetingMode.Normal);
    }
    private void SetupSensors(Sensor.TargetingMode mode)
    {
        attackSensor.targetingMode = mode;
        chaseSensor.targetingMode = mode;
    }
  public void FleeCommand(MarchWanderCommand command) // Gyoko (Gyoukou) - March FLEEEE
  {
        iconBack.sprite = flee;

        Debug.Log("FLEE!");
        if (CommadExists("GroupUp"))
        {
            goals.Remove(GetGoal("GroupUp"));
        }


        if (!CommadExists("GroupUp"))
        {
            goals.Add(new AgentGoal.Builder("Wander")
            .WithPriority(5)
            .WithDesiredEffect(beliefs["AgentMoving"])
            .Build());

            goals.Add(new AgentGoal.Builder("GroupUp")
            .WithPriority(10)
            .WithDesiredEffect(beliefs["NearPlayer"])
            .Build());

        }
    }
    public void StayCommand(StayIdleCommand command) // Tome - Stop
  {
        iconBack.sprite = neutral;
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
        iconBack.sprite = go;
        Debug.Log("FOLLOW!");
        if (CommadExists("GroupUp"))
        {
            goals.Remove(GetGoal("GroupUp"));
        }
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
