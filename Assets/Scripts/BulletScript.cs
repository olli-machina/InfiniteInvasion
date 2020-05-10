using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public int hitCounter = 0;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(transform.up * 150.0f);
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
