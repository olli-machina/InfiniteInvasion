﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorMovement : MonoBehaviour
{

    private float xMove, yMove;
    public float meteorSpeed;
    Rigidbody2D rb;
    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody2D>();
        CheckDirection();
    }

    public void CheckDirection()
    {
        if(gameObject.transform.position.x > 0.0f)
            xMove = (Random.Range(0.5f, -5.0f)) * meteorSpeed;
        else if(gameObject.transform.position.x < 0.0f)
            xMove = (Random.Range(5.0f, 0.0f)) * meteorSpeed;

        if(gameObject.transform.position.y > 33.0f)
            yMove = (Random.Range(0.5f, -5.0f)) * meteorSpeed;
        else if (gameObject.transform.position.y < 33.0f)
            yMove = (Random.Range(5.0f, 0.0f)) * meteorSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBounds();
    }

    void Move()
    {
        Vector2 newVelocity = new Vector2(xMove, yMove);
        rb.velocity = newVelocity;
    }

    void CheckBounds()
    {
        if (gameObject.transform.position.x > 38.0f || gameObject.transform.position.x < -42.0)
        {
            gameManager.SpawnMeteor();
            Destroy(gameObject);
        }


        if (gameObject.transform.position.y > 32.0f || gameObject.transform.position.y < -32.0)
        {
            gameManager.SpawnMeteor();
            Destroy(gameObject);
        }
    }
    
    void onCollisionEnter2D(Collider col)
    {
        if(col.tag == "Player")
        {
            meteorSpeed *= -1.0f;
        }
    }
}
