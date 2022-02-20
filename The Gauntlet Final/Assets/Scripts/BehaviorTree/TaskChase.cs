using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

using BehaviorTree;

public class TaskChase : Node
{
    private Transform _transform;
    private NavMeshAgent _agent;

    public TaskChase(Transform transform, NavMeshAgent agent)
    {
        _transform = transform;
        _agent = agent;
    }

    public override NodeState Evaluate()
    {
        GameObject player = GetData("Player") as GameObject;
        Vector3 playerPosition = player.transform.position;

        if(Vector3.Distance(_transform.position, playerPosition) > 0.01f)
        {
            _agent.SetDestination(playerPosition);
        }

        state = NodeState.RUNNING;
        return state;
    }
}
