using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed, jumpForce, wallJumpForce;
    public bool canJump,canWallJumpLeft, canWallJumpRight;
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
            canWallJumpLeft = false;
        }
        if (collision.gameObject.tag == "wallRight")
        {
            canWallJumpRight = false;
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            canJump = true;
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
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed;
        }
        if (Input.GetKey(KeyCode.W) && canJump == true)
        {
            rB.AddForce(Vector2.up * jumpForce);
        }


    }

}
