using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    float xMove = 10f;
    public float speed;
    float yMove = 10f;
    public float boundsLeft = -8.5f;
    public float boundsRight = 8.5f;
    public float boundsUp = -4.5f;
    public float boundsDown = -4.45f;
    Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        CheckInput();
    }

    void FixedUpdate()
    {
        Move();
        CheckBounds();
    }

    void CheckInput()
    {
        xMove = Input.GetAxis("Horizontal") * speed;
        yMove = Input.GetAxis("Vertical") * speed;
    }

    void Move()
    {
        Vector2 newVelocity = new Vector2(xMove, yMove);
        rb.velocity = newVelocity;
    }

    void CheckBounds()
    {
        Vector2 maxPosX;
        Vector2 maxPosY;
        //Horizontal bounds
        if (transform.position.x < boundsLeft)
        {
            maxPosX = new Vector2(boundsLeft, transform.position.y);
            transform.position = maxPosX;
        }
        else if (transform.position.x > boundsRight)
        {
            maxPosX = new Vector2(boundsRight, transform.position.y);
            transform.position = maxPosX;
        }
        //Vertical bounds
        if (transform.position.y < boundsDown)
        {
            maxPosY = new Vector2(transform.position.x, boundsDown);
            transform.position = maxPosY;
        }
        else if (transform.position.y > boundsUp)
        {
            maxPosY = new Vector2(transform.position.x, boundsUp);
            transform.position = maxPosY;
        }

    }
}
