using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownController : MonoBehaviour
{
    public Rigidbody2D body;
    public SpriteRenderer spriteR;

    public List<Sprite> nSprites;
    public List<Sprite> neSprites;
    public List<Sprite> eSprites;
    public List<Sprite> seSprites;
    public List<Sprite> sSprites;

    public float walkSpeed;
    public float frameRate;

    float idleTime;

    Vector2 direction;

    
    void Start()
    {
        
    }


    void Update()
    {   //get direction of input
        direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        //set walk based on direction
        body.velocity = direction * walkSpeed;

        //handle direction
        HandleSpriteFlip();

        //set sprite animation
        SetSprite();
    }

    void SetSprite()
    {
        List<Sprite> directionSprites = GetSpriteDirection();

        if (directionSprites != null)
        {   //holding a direction
            float playTime = Time.time - idleTime; //time since started walking
            int totalFrames = (int)(playTime * frameRate); //total frames since started
            int frame = totalFrames % directionSprites.Count; //current frame

            spriteR.sprite = directionSprites[frame];
        }
        else
        { //holding nothing, input is neutral
            idleTime = Time.time;
        }
    }

    void HandleSpriteFlip()
    {   //if we're facing right, and the player holds left, flip
        if(!spriteR.flipX && direction.x <0)
        {
            spriteR.flipX = true;
        } else if (spriteR.flipX && direction.x>0) //if we're facing left and the players holds right, flip
        {
            spriteR.flipX = false;
        }
    }

    List<Sprite> GetSpriteDirection()
    {

        List<Sprite> selectedSprites = null;
        if(direction.y > 0) //north
        {
            if(Mathf.Abs(direction.x) > 0) //east or west
            {
                selectedSprites = neSprites;
            } else //neutral X
            {
                selectedSprites = nSprites;
            }
        }else if(direction.y<0) //south
        {
            if (Mathf.Abs(direction.x) > 0) //east or west
            {
                selectedSprites = seSprites;
            }
            else //neutral X
            {
                selectedSprites = sSprites;
            }
        }
        else //neutral
        {
            if (Mathf.Abs(direction.x) > 0) //east or west
            {
                selectedSprites = eSprites;
            }
        }

        return selectedSprites;
    }
}
