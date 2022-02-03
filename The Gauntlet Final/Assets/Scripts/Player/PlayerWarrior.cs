using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWarrior : Player
{
    protected override void SetSpeed()
    {
        hyperSpeed = 20;
        speed = 10;
        reverseSpeed = 5f;
        jumpForce = 250;
    }
}
