﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    float xMove = 10f;
    public float speed, turnSpeed;
    float yMove = 10f;
    Rigidbody2D rb;
    public Vector2 newVelocity;

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
       // CheckBounds();
    }

    void CheckInput()
    {
        xMove = Input.GetAxis("Horizontal") * speed;
        yMove = Input.GetAxis("Vertical") * speed;
    }

    void Move()
    {
        newVelocity = new Vector2(xMove, yMove);
        rb.velocity = newVelocity;

        if (newVelocity != Vector2.zero)
            rb.MoveRotation(Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward, newVelocity), Time.fixedDeltaTime * turnSpeed));
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Meteor")
        {
            StartCoroutine(MeteorCollision());
        }
    }

    IEnumerator MeteorCollision()
    {
        rb.freezeRotation = true;
        yield return new WaitForSeconds(1.5f);
        rb.freezeRotation = false;
    }
    
}
