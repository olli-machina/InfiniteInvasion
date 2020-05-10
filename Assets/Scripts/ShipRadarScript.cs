using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipRadarScript : MonoBehaviour
{
    public int threatLevel;
    public GameObject radioBall;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (threatLevel >= 5)
        {
            radioBall.GetComponent<RadioBallScript>().IncomingMessage();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Swarm")
        {
            collision.gameObject.GetComponent<SwarmMovement>().nearColonyShip = true;
            collision.gameObject.GetComponent<SwarmMovement>().colonyShip = gameObject;
            threatLevel += 1;
            Debug.Log("Threat Level: " + threatLevel);
        }
    }
}
