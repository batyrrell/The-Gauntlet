using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPaladin : Player
{
    protected override void SetSpeed()
    {
        hyperSpeed = 30;
        speed = 15;
        reverseSpeed = 10;
        jumpForce = 350;
    }
}
