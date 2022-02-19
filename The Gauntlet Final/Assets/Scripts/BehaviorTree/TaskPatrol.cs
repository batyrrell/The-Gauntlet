using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

using BehaviorTree;
public class TaskPatrol : Node
{
    NavMeshAgent _agent;
    GameObject _npc;

    int _currentIndex = -1;
    float _waitTime = 1f;
    float _waitCounter = 0f;
    bool _waiting = false;
    public TaskPatrol(NavMeshAgent agent, GameObject npc)
    {
        _agent = agent;
        _npc = npc;
        agent.speed = npc.GetComponent<Enemy>().walkSpeed;
        agent.angularSpeed = npc.GetComponent<Enemy>().turnSpeed;
    }

    public override NodeState Evaluate()
    {
        if(_waiting)
        {
            _waitCounter += Time.deltaTime;
            if (_waitCounter >= _waitTime)
                _waiting = false;
        }
        else
        {
            float lastDist = Mathf.Infinity;
            for (int i = 0; i < GameWorld.Singleton.CheckPoints.Count; i++)
            {
                GameObject thisWP = GameWorld.Singleton.CheckPoints[i];
                float distance = Vector3.Distance(_npc.transform.position, thisWP.transform.position);
                if (distance < lastDist)
                {
                    _currentIndex = i - 1;
                    lastDist = distance;
                }
            }
        }
        state = NodeState.RUNNING;
        return state;
    }
}
