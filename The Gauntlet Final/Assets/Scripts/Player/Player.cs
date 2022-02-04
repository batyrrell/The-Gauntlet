using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : MonoBehaviour
{
    Rigidbody rb;

    //movement values
    float realSpeed;
    protected float hyperSpeed;
    protected float reverseSpeed;
    bool isOnGround = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
   

    protected void Move(float speed, float turnSpeed)
    {
        hyperSpeed = 1.5f * speed;
        reverseSpeed = speed / 2;
        realSpeed = Input.GetKey(KeyCode.LeftShift) ? hyperSpeed : speed;
        float h_Input = Input.GetAxis("Horizontal");
        float v_Input = Input.GetAxis("Vertical");
        if (isOnGround)
        {
            if (v_Input > 0)
            { transform.Translate(Vector3.forward * Time.deltaTime * realSpeed * v_Input); }
            else if (v_Input < 0)
            { transform.Translate(Vector3.forward * Time.deltaTime * reverseSpeed * v_Input); }
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * h_Input);
        }
    }

    protected void Jump(float jumpForce)
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(isOnGround)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isOnGround = false;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }
}
