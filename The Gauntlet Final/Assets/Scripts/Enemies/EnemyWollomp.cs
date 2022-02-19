using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//INHERITANCE

public class EnemyWollomp : Enemy
{

    
    State currentState;

    int health = 200;
    float _walkSpeed = 1;
    float _runSpeed = 3;
    float _turnSpeed = 50;
    string creatureType = "Wollomp";
    //Rigidbody enemyRB;

    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            playerTransform = player.transform;
        }
        //enemyRB = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        SetHealth(health, creatureType);
        MoveSet(_walkSpeed, _runSpeed, _turnSpeed);
        currentState = new Idle(this.gameObject, agent, playerTransform);
       
    }

    void Update()
    {
        currentState = currentState.Process();
        currentState.PrintDebug();
    }
}
