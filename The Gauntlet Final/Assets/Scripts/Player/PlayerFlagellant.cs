using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//INHERITANCE
public class PlayerFlagellant : Player
{
    
    float _speed = 5;
    float _turnSpeed = 100;
    float jumpForce = 100;
    void LateUpdate()
    {
        Move(_speed, _turnSpeed);
        Jump();
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
        }
    }
}
