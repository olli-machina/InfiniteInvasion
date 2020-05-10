using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipRadarScript : MonoBehaviour
{
    public int threatLevel;
    public GameObject radioBall, messageBorder, message;
    private bool messageReady;
    private Collider2D enemy;

    // Start is called before the first frame update
    void Start()
    {
        messageReady = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (threatLevel >= 5 && messageReady)
        {
            StartCoroutine(MessageIncoming());
        }
    }

    IEnumerator MessageIncoming()
    {
        radioBall.GetComponent<RadioBallScript>().IncomingMessage();
        messageBorder.SetActive(true);
        message.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        radioBall.GetComponent<RadioBallScript>().EndMessage();
        messageBorder.SetActive(false);
        message.SetActive(false);
        StartCoroutine(StartCooldown());
    }

    IEnumerator StartCooldown()
    {
        messageReady = false;
        yield return new WaitForSeconds(15f);
        messageReady = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Swarm")
        {
            enemy = collision;
            collision.gameObject.GetComponent<SwarmMovement>().nearColonyShip = true;
            collision.gameObject.GetComponent<SwarmMovement>().colonyShip = gameObject;
            threatLevel += 1;
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Swarm")
        {
            collision.gameObject.GetComponent<SwarmMovement>().nearColonyShip = false;
            collision.gameObject.GetComponent<SwarmMovement>().colonyShip = null;
            threatLevel -= 1;
        }
    }
}
