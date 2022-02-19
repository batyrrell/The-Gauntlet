using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Wander : State
{

    //INHERITANCE
    Vector3 wanderTarget = Vector3.zero;

    public Wander(GameObject _npc, NavMeshAgent _agent, Transform _player)
                :base(_npc, _agent, _player)
    {
        name = STATE.WANDER;
        agent.isStopped = false;
    }


    //POLYMORPHISM
    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        debugWander++;
        float wanderRadius = 10;
        float wanderDistance = 10;
        float wanderJitter = 1;

        wanderTarget += new Vector3(Random.Range(1.0f, 1.0f) * wanderJitter, 0, Random.Range(-1.0f, 1.0f) * wanderJitter);
        wanderTarget.Normalize();
        wanderTarget *= wanderRadius;

        Vector3 targetLocal = wanderTarget + new Vector3(0, 0, wanderDistance);
        Vector3 targetWorld = npc.gameObject.transform.InverseTransformVector(targetLocal);



        if(CanSeePlayer())
        {
            nextState = new Pursue(npc, agent, player);
            stage = EVENT.EXIT;
        }

        if(Random.Range(0, 5000) < 10)
        {
            nextState = new Patrol(npc, agent, player);
            stage = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
