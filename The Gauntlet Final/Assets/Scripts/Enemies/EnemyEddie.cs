using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEddie : Enemy
{
    int health = 100;
    float speed = 10;
    float turnSpeed = 150;
    string creatureType = "Eddie";
    float xRange = 20;
    float zRange = 20;

    void Start()
    {
        SetHealth(health, creatureType);
        MoveSet(speed, turnSpeed);
    }

    private void LateUpdate()
    {
        Chase(xRange, zRange);
    }
}
