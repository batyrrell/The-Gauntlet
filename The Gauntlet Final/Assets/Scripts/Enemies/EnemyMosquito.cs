using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMosquito : Enemy
{
    int health = 25;
    float speed = 20;
    float turnSpeed = 200;
    string creatureType = "Mosquito";
    float xRange = 10;
    float zRange = 10;
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
