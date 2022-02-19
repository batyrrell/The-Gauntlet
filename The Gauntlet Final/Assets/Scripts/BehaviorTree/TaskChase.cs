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
        GameObject player = GetData("Player");
        Transform playerTransform = player.transform;

        if(Vector3.Distance(_transform.position, playerTransform.position) > 0.01f)
        {
            _agent.SetDestination(playerTransform.position);
        }

        state = NodeState.RUNNING;
        return state;
    }
}
