using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float enemyspeed;
    public string direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "wallLeft")
        {
            direction = "left";
        }
        if (collision.gameObject.tag == "wallRight")
        {
            direction = "right";
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (direction == "left")
        {
            transform.position += Vector3.left * enemyspeed;
        }
        if (direction == "right")
        {
            transform.position += Vector3.right * enemyspeed;
        }
    }
}
