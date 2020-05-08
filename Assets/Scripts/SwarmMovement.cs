using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmMovement : MonoBehaviour
{
    public float moveSpeed;
    private int target, ship;
    private Vector3 targetPosition;
    private GameManager gameManager;
    private GameObject player, ship1, ship2, ship3, ship4;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        ship1 = GameObject.Find("Ship1");
        ship2 = GameObject.Find("Ship2");
        ship3 = GameObject.Find("Ship3");
        ship4 = GameObject.Find("Ship4");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        target = Random.Range(0, 3);
    }

    // Update is called once per frame
    void Update()
    {
        float step = moveSpeed * Time.deltaTime;
        if (target == 0) //player is target
            targetPosition = player.transform.position;
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
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            player.GetComponent<PlayerScript>().DamageHealth(1);
            Destroy(gameObject);
        }
        else if (col.tag == "Bullet")
        {

        }
    }
}
