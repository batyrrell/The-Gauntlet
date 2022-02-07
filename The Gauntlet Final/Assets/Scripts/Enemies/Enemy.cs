using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[DefaultExecutionOrder(1000)]
public abstract class Enemy : MonoBehaviour
{
    public Transform[] points;
    private int destPoint = 0;
    protected NavMeshAgent agent;

    int creatureHealth;
    public GameObject[] creature { get; }
    public GameObject player { get; set; }
    //Rigidbody enemyRB;
    Vector3 playerPos;
    Vector3 playerDistance;
    int playerType;
    float s;
    float tS;

    protected bool onLoop = false;

    void Start()
    {
        playerType = PlayerPrefs.GetInt("Difficulty");
        //enemyRB = GetComponent<Rigidbody>();
    }

    public void Spawn(int creatureType, Vector3 creaturePos, Vector3 creatureOrientation)
    {
        Instantiate(creature[creatureType], creaturePos, Quaternion.Euler(creatureOrientation));
    }
    protected void SetHealth(int health, string tag)
    {
        creatureHealth = health;
        Debug.Log($"A(n) {tag} has {creatureHealth} health.");
    }

    protected void FindPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    protected void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
    }

    void Update()
    {
        // Choose the next destination point when the agent gets
        // close to the current one.
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GotoNextPoint();
    }

    private void OnCollisionEnter(Collision collision)
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
    }

    protected void MoveSet(float speed, float turnSpeed)
    {
        s = speed;
        tS = turnSpeed;
    }

    protected bool inRange(float range)
    {
        if (playerDistance.x < range && playerDistance.x > -range)
        {
            if (playerDistance.y < range && playerDistance.y > -range)
            {
                if (playerDistance.z < range && playerDistance.z > -range)
                {
                    return true;
                }
                else { return false; }
            }
            else { return false; }
        }
        else { return false; }
    }


    protected void Chase()
    {
        playerPos = player.transform.position;
        playerDistance = playerPos - transform.position;
        transform.Translate(playerDistance * s * Time.deltaTime);
        transform.Rotate(Vector3.up * tS * Time.deltaTime);
    }
}
