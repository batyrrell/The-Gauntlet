using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPaladin : Player
{
    float speed = 15;
    float jumpForce = 350;
    void LateUpdate()
    {
        Move(speed);
        Jump(jumpForce);
    }
}
