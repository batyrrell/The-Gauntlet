using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWollomp : Enemy
{
    int health = 200;
    float speed = 5;
    float turnSpeed = 50;
    string creatureType = "Wollomp";
    float xRange = 30;
    float zRange = 30;
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
