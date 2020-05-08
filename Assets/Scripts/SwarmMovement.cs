using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmMovement : MonoBehaviour
{

    private float movementDirX;

    // Start is called before the first frame update
    void Start()
    {
        //movementDirX = Random.RandomRange(0.0f, )
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
