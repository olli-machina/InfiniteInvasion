﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public int hitCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.up * 500.0f);
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Bounds")
            Destroy(gameObject);

        if(col.tag == "Swarm")
        {
            hitCounter++;
            //put combo instructions here
        }
    }

}
