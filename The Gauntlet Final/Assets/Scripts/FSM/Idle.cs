using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Idle : State
{

    //INHERITANCE
    public Idle(GameObject _npc, NavMeshAgent _agent, Transform _player)
                :base(_npc, _agent, _player)
    {
        name = STATE.IDLE;
    }

    //POLYMORPHISM

    public override void Enter()
    {
        
        base.Enter();
    }

    public override void Update()
    {
        int rR = Random.Range(0, 5000);
        debugIdle++;
        if (CanSeePlayer())
        {
            nextState = new Pursue(npc, agent, player);
            stage = EVENT.EXIT;
        }
        else if(Spooked())
        {
            nextState = new RunAway(npc, agent, player);
            stage = EVENT.EXIT;
        }
        else if(rR < 10)
        {
            nextState = new Patrol(npc, agent, player);
            stage = EVENT.EXIT;
        }
        else if(rR < 200 && rR > 10)
        {
            nextState = new Wander(npc, agent, player);
            stage = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
