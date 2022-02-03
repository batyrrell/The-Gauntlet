using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : MonoBehaviour
{
    Rigidbody rb;

    //movement values
    float realSpeed;
    protected float hyperSpeed;
    protected float speed;
    protected float reverseSpeed;
    protected float jumpForce;
    protected float turnSpeed = 100;
    bool isOnGround = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        SetSpeed();
    }


    void Update()
    {
        realSpeed = Input.GetKey(KeyCode.LeftShift) ? hyperSpeed : speed;
    }

    void LateUpdate()
    {
        if (isOnGround)
        {
            Move();
        }

        Jump();
    }

    protected abstract void SetSpeed();
   

    void Move()
    {
        float h_Input = Input.GetAxis("Horizontal");
        float v_Input = Input.GetAxis("Vertical");
        if (v_Input > 0)
        { transform.Translate(Vector3.forward * Time.deltaTime * realSpeed * v_Input); }
        else if (v_Input < 0)
        { transform.Translate(Vector3.forward * Time.deltaTime * reverseSpeed * v_Input);  }
        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * h_Input);
    }

    void Jump()
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
