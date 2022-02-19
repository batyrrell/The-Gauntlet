using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//INHERITANCE
public class RunAway : State
{
    GameObject safeSpot;
    
    public RunAway(GameObject _npc, NavMeshAgent _agent, Transform _player)
                :base(_npc, _agent, _player)
    {
        name = STATE.RUNAWAY;
    }

    //POLYMORPHISM

    public override void Enter()
    {

        safeSpot = GameObject.FindGameObjectWithTag("Safespot");
        agent.speed = npc.GetComponent<Enemy>().runSpeed;
        agent.angularSpeed = npc.GetComponent<Enemy>().turnSpeed;
        agent.SetDestination(safeSpot.transform.position);
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
