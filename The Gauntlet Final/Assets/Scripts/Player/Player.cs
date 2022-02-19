using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Player : MonoBehaviour
{

    
    protected Rigidbody rb;

    //movement values
    protected float realSpeed;
    protected float hyperSpeed;
    protected float reverseSpeed;
    protected bool isOnGround = true;

    float zBound = 30;
    float xBound = 30;

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

    //ABSTRACTION
    protected abstract void Jump();

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }

    protected  void ConstrainPlayerPosition()
    {
        if (transform.position.z < -zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBound);
        }
        if (transform.position.z > zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
        }
        if (transform.position.x < -xBound)
        {
            transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xBound)
        {
            transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
        }
    }
}
