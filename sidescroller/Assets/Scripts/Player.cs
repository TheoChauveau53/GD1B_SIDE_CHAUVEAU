using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed, jumpForce, wallJumpForce;
    public bool canJump,canWallJumpLeft, canWallJumpRight, canWalk;
    public string lastWallJump;
    public Rigidbody2D rB;

    void Start()
    {
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            canJump = false;
        }
        if (collision.gameObject.tag == "wallLeft")
        {
            canWallJumpRight = false;
        }
        if (collision.gameObject.tag == "wallRight")
        {
            canWallJumpLeft = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            canJump = true;
            lastWallJump = "";
        }
        if (collision.gameObject.tag == "wallLeft")
        {
            canWallJumpRight = true;
        }
        if (collision.gameObject.tag == "wallRight")
        {
            canWallJumpLeft = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) && !canWallJumpRight && canWalk)
        {
            transform.position += Vector3.left * speed;
        }
        if (Input.GetKey(KeyCode.D)&& !canWallJumpLeft && canWalk)
        {
            transform.position += Vector3.right * speed;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (canJump == true)
            {
                rB.velocity = new Vector2(rB.velocity.x, jumpForce);
            }
            else if(canWallJumpLeft == true && lastWallJump!="Right")
            {
                rB.velocity = new Vector2(-wallJumpForce , jumpForce);
                canWallJumpLeft = false;
                lastWallJump = "Right";
                canWalk = false;
                Invoke("CanWalk",0.5f);
            }
            else if (canWallJumpRight == true && lastWallJump != "Left")
            {
                rB.velocity = new Vector2(wallJumpForce, jumpForce);
                canWallJumpRight = false;
                lastWallJump = "Left";
                canWalk = false;
                Invoke("CanWalk", 0.5f);
            }
        }
    }
    private void CanWalk()
    {
        canWalk = true;
    }

}
