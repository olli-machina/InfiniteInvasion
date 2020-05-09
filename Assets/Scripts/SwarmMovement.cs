﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmMovement : MonoBehaviour
{
    public float moveSpeed;
    private int target, ship;
    private Vector3 targetPosition;
    private GameManager gameManager;
    private GameObject player, ship1, ship2, ship3, ship4, cameraShake;
    public GameObject attackPoints, basicPoints;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        ship1 = GameObject.Find("ATLAS");
        ship2 = GameObject.Find("GOLIATH");
        ship3 = GameObject.Find("JUNO");
        ship4 = GameObject.Find("ORION");
        cameraShake = GameObject.Find("Main Camera");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        target = Random.Range(0, 3);
    }

    // Update is called once per frame
    void Update()
    {
        float step = moveSpeed * Time.deltaTime;
        if (target == 0) //player is target
        {
            targetPosition = player.transform.position;
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
        }
        else //ship is target
        {
            ship = gameManager.SetShip();
            if (ship == 1)
                targetPosition = ship1.transform.position;
            if (ship == 2)
                targetPosition = ship2.transform.position;
            if (ship == 3)
                targetPosition = ship3.transform.position;
            if (ship == 4)
                targetPosition = ship4.transform.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);



        SpreadOut();
    }

    public void SpreadOut()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.tag);
        if(col.tag == "Player")
        {
            player.GetComponent<PlayerScript>().DamageHealth(1);
            cameraShake.GetComponent<CameraShake>().Shake();
            Destroy(gameObject);
        }
        else if (col.tag == "Bullet")
        {
            if (target == 0)
            {
                gameManager.ChangeScore(25);
            }
            else
            {
                gameManager.ChangeScore(10);
            }

            ShowPoints();
            Destroy(gameObject);
            Destroy(col);
        }
        else if (col.tag == "Meteor")
        {
            Destroy(gameObject);
        }
        else if (col.tag == "Ship")
        {
            ship1.GetComponent<ColonyShipScript>().health -= 1;
            ship1.GetComponent<ColonyShipScript>().UpdateHealth();
            Destroy(gameObject);
        }
    }

    void ShowPoints()
    {
        if (target == 0)
        {
            Instantiate(attackPoints, gameObject.transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(basicPoints, gameObject.transform.position, Quaternion.identity);
        }
    }
}
