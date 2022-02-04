using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    int creatureHealth;
    public GameObject[] creature { get; }
    GameObject player;
    Vector3 playerPos;
    Vector3 playerDistance;
    Vector3 playerChase;
    Vector3 loop;
    int playerType;
    float s;
    float tS;
    float room;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerType = PlayerPrefs.GetInt("Difficulty");
    }

    public void Spawn(int creatureType, Vector3 creaturePos, Vector3 creatureOrientation)
    {
        Instantiate(creature[creatureType], creaturePos, Quaternion.Euler(creatureOrientation));
    }
    protected void SetHealth(int health, string tag)
    {
        creatureHealth = health;
        Debug.Log($"A {tag} has {creatureHealth} health.");
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

    protected void Patrol(float roomSize, Vector3 loopStart)
    {
        room = roomSize;
        loop = loopStart;
    }

    protected void ReturnToPatrol()
    {
        if (this.transform.position != loop)
        { this.transform.Translate(loop.normalized); }
    }

    protected void Chase(float xRange, float zRange)
    {
        playerPos = player.transform.position;
        playerDistance = (playerPos - this.transform.position);
        if (playerDistance.x < xRange && playerDistance.x > -xRange)
        {
            if(playerDistance.z < zRange && playerDistance.z > -zRange)
            {
                playerChase = playerDistance.normalized;
                this.transform.Translate(playerChase * s);
            }
        }
    }
}
