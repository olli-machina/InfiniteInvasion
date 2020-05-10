using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public int hitCounter = 0;
    Rigidbody2D rb;
    Transform player;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = transform.up * 50.0f;
        //rb.AddForce(player.up * 500.0f);
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
