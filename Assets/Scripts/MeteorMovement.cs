﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorMovement : MonoBehaviour
{

    private float xMove, yMove;
    private bool flipped = false;
    public float meteorSpeed;
    Rigidbody2D rb;
    public GameObject forceField;
    private Vector3 spawnRotation;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        CheckDirection();
    }

    public void CheckDirection()
    {
        if(gameObject.transform.position.x > 0.0f)
            xMove = (Random.Range(0.5f, -5.0f)) * meteorSpeed;
        else if(gameObject.transform.position.x < 0.0f)
            xMove = (Random.Range(5.0f, 1.0f)) * meteorSpeed;

        if(gameObject.transform.position.y > 33.0f)
            yMove = (Random.Range(0.5f, -0.5f)) * meteorSpeed;
        else if (gameObject.transform.position.y < 33.0f)
            yMove = (Random.Range(5.0f, 0.5f)) * meteorSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBounds();
    }

    void Move()
    {
        Vector2 newVelocity;
        if (!flipped)
        {
            newVelocity = new Vector2(xMove, yMove);
        }
        else
        {
            newVelocity = new Vector2(-xMove, -yMove);
        }

        rb.velocity = newVelocity;
    }

    void CheckBounds()
    {
        if (gameObject.transform.position.x > 71.0f || gameObject.transform.position.x < -77.0)
        {
            GameManager.singleton.SpawnMeteor();
            Destroy(gameObject);
        }


        if (gameObject.transform.position.y > 50.0f || gameObject.transform.position.y < -50.0)
        {
            GameManager.singleton.SpawnMeteor();
            Destroy(gameObject);
        }
    }
    
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            GameManager.singleton.SpawnMeteor();
            Destroy(gameObject);
        }

        else if (col.gameObject.tag == "Ship")
        {
            GameObject spawnedField = (GameObject)Instantiate(forceField, transform.position, Quaternion.identity);
            spawnedField.GetComponent<ForceFieldScript>().ship = col.gameObject.GetComponent<Transform>();
            flipped = !flipped;
        }

        if(col.gameObject.tag == "Bounds")
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), col.gameObject.GetComponent<Collider2D>());
        }
    }
}
