using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : State
{

    //INHERITANCE
    int currentIndex = -1;

    public Patrol(GameObject _npc, NavMeshAgent _agent, Transform _player)
                :base(_npc, _agent, _player)
    {
        name = STATE.PATROL;
        agent.speed = npc.GetComponent<Enemy>().walkSpeed;
        agent.angularSpeed = npc.GetComponent<Enemy>().turnSpeed;
        agent.isStopped = false;
    }

    //POLYMORPHISM

    public override void Enter()
    {
        
        float lastDist = Mathf.Infinity;
        for(int i = 0; i<GameWorld.Singleton.CheckPoints.Count; i++)
        {
            GameObject thisWP = GameWorld.Singleton.CheckPoints[i];
            float distance = Vector3.Distance(npc.transform.position, thisWP.transform.position);
            if(distance < lastDist)
            {
                currentIndex = i - 1;
                lastDist = distance;
            }
        }
        base.Enter();
    }

    public override void Update()
    {
        debugPatrol++;
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
        else if (agent.remainingDistance<1)
        {
            
            if (currentIndex >= GameWorld.Singleton.CheckPoints.Count - 1)
                currentIndex = 0;
            else
                currentIndex++;

            agent.SetDestination(GameWorld.Singleton.CheckPoints[currentIndex].transform.position);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
