using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

using BehaviorTree;
public abstract class Enemy : BTree
{

    public static float playerRange = 6f;
    int creatureHealth;

    //ENCAPSULATION
    public GameObject player { get; set; }
    protected Transform playerTransform;
    protected NavMeshAgent agent;
    

    public float walkSpeed { get; set; }
    public float runSpeed { get; set; }
    public float turnSpeed { get; set; }


    protected void SetHealth(int health, string tag)
    {
        creatureHealth = health;
        Debug.Log($"A(n) {tag} has {creatureHealth} health.");
    }

   
    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
            if (playerType == 0)
            { creatureHealth -= 20; }
            else if (playerType == 1)
            { creatureHealth -= 15; }
            else if (playerType == 0)
            { creatureHealth -= 5; }
        }
    }*/

    protected void MoveSet(float _walkSpeed, float _runSpeed, float _turnSpeed)
    {
        walkSpeed = _walkSpeed;
        runSpeed = _runSpeed;
        turnSpeed = _turnSpeed;
    }

    protected override Node SetupTree()
    {
        GameObject npc = this.gameObject;

        Node root = new Selector(new List<Node>
        {
            new Sequence(new List<Node>
            {
                new PlayerInRange(transform),
                new TaskChase(transform, agent),
            }),
            new TaskPatrol(agent, npc),
        });

        return root;
    }
}
