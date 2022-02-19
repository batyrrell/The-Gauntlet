using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//INHERITANCE
public class PlayerPaladin : Player
{
    
    float _speed = 15;
    float _turnSpeed = 200;
    float jumpForce = 200;
    float doubleJumpForce = 300;
    bool doubleJump;

    void LateUpdate()
    {
        Move(_speed, _turnSpeed);
        Jump();
        doubleJump = true;
    }

    protected override void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isOnGround)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isOnGround = false;
            }
            if (doubleJump)
            {
                rb.AddForce(Vector3.up * doubleJumpForce, ForceMode.Impulse);
                doubleJump = false;
            }
        }
    }
}
