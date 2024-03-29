using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{ 
    public float turnSpeed = 5.0f;      //turn speed for camera rotation
    public GameObject player;           //this is the area to assign the player as the object (in unity)

    public Transform playerTransform; //this is all the orientation info of an object
    private Vector3 offset;

    //camera offset info
    [SerializeField] private float yOffset = -1.0f;
    [SerializeField] private float zOffset = -2.0f;

    void LateUpdate()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            playerTransform = player.transform;
            offset = new Vector3(playerTransform.position.x, playerTransform.position.y + yOffset, playerTransform.position.z + zOffset);
        }
        else
        {
            //creates a rotation which rotates angle degrees around axis (at offset position)
            offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;

            //sets the camera position to offset of player
            transform.position = playerTransform.position + offset;

            //makes sure the camera looks at player
            transform.LookAt(playerTransform.position);
        }
    }

   
}
