using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pursue : State
{

    //INHERITANCE
    public Pursue(GameObject _npc, NavMeshAgent _agent, Transform _player)
                :base(_npc, _agent, _player)
    {
        name = STATE.PURSUE;
        agent.speed = npc.GetComponent<Enemy>().runSpeed;
        agent.angularSpeed = npc.GetComponent<Enemy>().turnSpeed;
        agent.isStopped = false;
    }

    //POLYMORPHISM
    public override void Enter()
    {
        
        base.Enter();
    }

    public override void Update()
    {
        debugPursue++;
        agent.SetDestination(player.position);
        if(agent.hasPath)
        {
            if(!CanSeePlayer())
            {
                nextState = new Patrol(npc, agent, player);
                stage = EVENT.EXIT;
            }
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
