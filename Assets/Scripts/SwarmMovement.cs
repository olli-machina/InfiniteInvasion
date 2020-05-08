using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmMovement : MonoBehaviour
{

    private float movementDirX;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void onTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {

        }
        else if (col.tag == "Bullet")
        {

        }
    }
}
