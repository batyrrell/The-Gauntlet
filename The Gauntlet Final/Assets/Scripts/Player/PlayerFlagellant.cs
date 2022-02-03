using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlagellant : Player
{
    protected override void SetSpeed()
    {
        hyperSpeed = 10;
        speed = 5;
        reverseSpeed = 2.5f;
        jumpForce = 100;
    }
}
