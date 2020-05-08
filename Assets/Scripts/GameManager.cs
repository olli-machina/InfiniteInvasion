﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject Player;
    public GameObject Meteor, SwarmMember;
    Vector3 position;
    private int shipCounter = 0;
    private float spawnTimer = 0.0f;
    public Vector3 spawnPoint1 = new Vector3(1.9f, -1.72f, 0.0f),
                    spawnPoint2 = new Vector3(0.58f, -2.74f, 0.0f),
                    spawnPoint3 = new Vector3(0.97f, 0.23f, 0.0f),
                    spawnPoint4 = new Vector3(2.32f, -0.13f, 0.0f),
                    spawnPoint5 = new Vector3(1.54f, -1.24f, 0.0f),
                    spawnPoint6 = new Vector3(-0.2f, -0.64f, 0.0f),
                    spawnPoint7 = new Vector3(-1.79f, -0.79f, 0.0f),
                    spawnPoint8 = new Vector3(-0.41f, 0.5f, 0.0f),
                    spawnPoint9 = new Vector3(-1.22f, 2.03f, 0.0f),
                    spawnPoint10 = new Vector3(1.08f, 2.12f, 0.0f);



    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if(spawnTimer >= 5.0f)
        {
            SpawnSwarm();
            spawnTimer = 0.0f;
        }
    }

    public void SpawnMeteor()
    {
        var rL = Random.Range(0, 2);
        if(rL == 0)
            position = new Vector3(Random.Range(-41.0f, -32.0f), Random.Range(-31.0f, 31.0f), 0);
        else
            position = new Vector3(Random.Range(32.0f, 37.0f), Random.Range(-31.0f, 31.0f), 0);

        Instantiate(Meteor, position, Quaternion.identity);
    }

    public int SetShip()
    {
        if (shipCounter > 100)
        {
            shipCounter = 0;
            return 4;
        }
        else if (shipCounter > 75)
            return 3;
        else if (shipCounter > 50)
            return 2;
        else
            return 1;
    }

    public void SpawnSwarm()
    {
        Instantiate(SwarmMember, spawnPoint1, Quaternion.identity);
        Instantiate(SwarmMember, spawnPoint2, Quaternion.identity);
        Instantiate(SwarmMember, spawnPoint3, Quaternion.identity);
        Instantiate(SwarmMember, spawnPoint4, Quaternion.identity);
        Instantiate(SwarmMember, spawnPoint5, Quaternion.identity);
        Instantiate(SwarmMember, spawnPoint6, Quaternion.identity);
        Instantiate(SwarmMember, spawnPoint7, Quaternion.identity);
        Instantiate(SwarmMember, spawnPoint8, Quaternion.identity);
        Instantiate(SwarmMember, spawnPoint9, Quaternion.identity);
        Instantiate(SwarmMember, spawnPoint10, Quaternion.identity);
    }
}
