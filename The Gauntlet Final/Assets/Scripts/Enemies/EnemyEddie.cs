using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//INHERITANCE
public class EnemyEddie : Enemy
{

    
    State currentState;

    int health = 100;
    float _walkSpeed = 5;
    float _runSpeed = 7;    
    float _turnSpeed = 150;
    string creatureType = "Eddie";
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
