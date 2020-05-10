using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmMovement : MonoBehaviour
{
    public float moveSpeed;
    private int target, ship;
    private Vector3 targetPosition;
    private GameObject player, ship1, ship2, ship3, ship4, cameraShake;
    public GameObject attackPoints, basicPoints;
    private Transform pointsSpawn;
    public bool nearColonyShip;
    public GameObject colonyShip;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        ship1 = GameObject.Find("ATLAS");
        ship2 = GameObject.Find("GOLIATH");
        ship3 = GameObject.Find("JUNO");
        ship4 = GameObject.Find("ORION");
        pointsSpawn = GameObject.Find("UIPoints").GetComponent<Transform>();
        cameraShake = GameObject.Find("Main Camera");
        target = Random.Range(0, 3);
        ship = GameManager.singleton.randShipNumber;
        nearColonyShip = false;
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
            ChooseShip();
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
       // SpreadOut();
    }

    public void SpreadOut()
    {
        
    }

    public void ChooseShip()
    {
        if (ship == 0)
        {
            if (ship1 != null)
                targetPosition = ship1.transform.position;
            else
                ship++;
        }
        if (ship == 1)
        {
            if (ship2 != null)
                targetPosition = ship2.transform.position;
            else
                ship++;
        }
        if (ship == 2)
        {
            if (ship3 != null)
                targetPosition = ship3.transform.position;
            else
                ship++;

        }
        if (ship == 3)
        {
            if (ship4 != null)
                targetPosition = ship4.transform.position;
            else
                ship = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            player.GetComponent<PlayerScript>().DamageHealth(1);
            cameraShake.GetComponent<CameraShake>().Shake();
            if (nearColonyShip && colonyShip.GetComponent<ShipRadarScript>().threatLevel > 0)
            {
                colonyShip.GetComponent<ShipRadarScript>().threatLevel -= 1;
            }
            Destroy(gameObject);
        }
        else if (col.tag == "Bullet")
        {
            if (target == 0)
            {
                GameManager.singleton.ChangeScore(25);
            }
            else
            {
                GameManager.singleton.ChangeScore(10);
            }

            ShowPoints();
            if (nearColonyShip && colonyShip.GetComponent<ShipRadarScript>().threatLevel > 0)
            {
                colonyShip.GetComponent<ShipRadarScript>().threatLevel -= 1;
            }
            Destroy(gameObject);
            Destroy(col);
        }
        else if (col.tag == "Meteor")
        {
            if (nearColonyShip && colonyShip.GetComponent<ShipRadarScript>().threatLevel > 0)
            {
                colonyShip.GetComponent<ShipRadarScript>().threatLevel -= 1;
            }
            Destroy(gameObject);
        }
        else if (col.tag == "Ship")
        {
            col.GetComponent<ColonyShipScript>().health -= 1;
            col.GetComponent<ColonyShipScript>().UpdateHealth();
            if (nearColonyShip && colonyShip.GetComponent<ShipRadarScript>().threatLevel > 0)
            {
                colonyShip.GetComponent<ShipRadarScript>().threatLevel -= 1;
            }
            Destroy(gameObject);
        }
    }

    void ShowPoints()
    {
        if (target == 0)
        {
            Instantiate(attackPoints, gameObject.transform.position, Quaternion.identity, pointsSpawn);
        }
        else
        {
            Instantiate(basicPoints, gameObject.transform.position, Quaternion.identity, pointsSpawn);
        }
    }
}
