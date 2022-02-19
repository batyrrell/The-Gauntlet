using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;

public class PlayerInRange : Node
{
    private Transform _transform;
    private static int _enemyLayerMask = 1 << 6;

    public PlayerInRange(Transform transform)
    {
        _transform = transform;
    }

    public override NodeState Evaluate()
    {
        object player = GetData("Player");
        if (player == null)
        {
            Collider[] colliders = Physics.OverlapSphere(_transform.position, Enemy.playerRange, _enemyLayerMask);


            if (colliders.Length > 0)
            {
                parent.parent.SetData("Player", colliders[0].transform);
                state = NodeState.SUCCESS;
                return state;
            }

            state = NodeState.FAILURE;
            return state;
        }


        state = NodeState.SUCCESS;
        return state;
    }
}
