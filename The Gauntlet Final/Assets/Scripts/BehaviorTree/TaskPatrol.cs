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
        Debug.Log("Evaluating");
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
                    _currentIndex = i;
                    lastDist = distance;
                    Debug.Log(i);
                }
            }
            if (_agent.remainingDistance < 1)
            {
                if (_currentIndex >= GameWorld.Singleton.CheckPoints.Count - 1)
                {
                    _currentIndex = 0;
                    Debug.Log("Reset");
                }
                else
                {
                    _currentIndex++;
                    Debug.Log("Destination: " + _currentIndex);
                }

                _agent.SetDestination(GameWorld.Singleton.CheckPoints[_currentIndex].transform.position);
                Debug.Log("Patrolling");
            }
        }
        
        state = NodeState.RUNNING;
        return state;
    }
}
