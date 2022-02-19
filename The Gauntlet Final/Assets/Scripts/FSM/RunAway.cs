using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RunAway : State
{

    //INHERITANCE
    GameObject target;
    public RunAway(GameObject _npc, NavMeshAgent _agent, Transform _player)
                :base(_npc, _agent, _player)
    {
        name = STATE.RUNAWAY;
    }

    //POLYMORPHISM

    public override void Enter()
    {
        
        target = GameWorld.instance.safeSpot;
        agent.speed = npc.GetComponent<Enemy>().runSpeed;
        agent.angularSpeed = npc.GetComponent<Enemy>().turnSpeed;
        agent.SetDestination(target.transform.position);
        base.Enter();
    }

    public override void Update()
    {
        debugRun++;
        if (agent.remainingDistance < 1)
        {
            nextState = new Idle(npc, agent, player);
            stage = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
