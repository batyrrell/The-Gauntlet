using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlagellant : Player
{ 
    float speed = 5;
    float jumpForce = 100;
    void LateUpdate()
    {
        Move(speed);
        Jump(jumpForce);
    }
}
