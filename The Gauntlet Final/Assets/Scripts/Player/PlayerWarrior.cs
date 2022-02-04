using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWarrior : Player
{
    float speed = 10;
    float turnSpeed = 150;
    float jumpForce = 250;
    void LateUpdate()
    {
        Move(speed, turnSpeed);
        Jump(jumpForce);
    }
}
