using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMosquito : Enemy
{
    int health = 25;
    float speed = 10;
    float turnSpeed = 200;
    string creatureType = "Mosquito";
    float range = 20;

    void Start()
    {
        SetHealth(health, creatureType);
        MoveSet(speed, turnSpeed);
        agent = GetComponent<NavMeshAgent>();

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = false;

        GotoNextPoint();
    }

    private void Update()
    {
        FindPlayer();
        if (inRange(range))
        { Chase(); }
        else if (!agent.pathPending && agent.remainingDistance < 0.5f) // Choose the next destination point when the agent gets
                                                                       // close to the current one.
        { GotoNextPoint(); }
    }
}
