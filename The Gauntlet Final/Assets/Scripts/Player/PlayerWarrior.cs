using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWarrior : Player
{
    float speed = 10;
    float jumpForce = 250;
    void LateUpdate()
    {
        Move(speed);
        Jump(jumpForce);
    }
}
