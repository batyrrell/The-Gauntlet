using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//INHERITANCE
public class PlayerWarrior : Player
{
    
    float _speed = 10;
    float _turnSpeed = 150;
    float jumpForce = 250;

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
