using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwarmMovement : MonoBehaviour
{
    public float moveSpeed, turnSpeed;
    private int target, ship;
    private Vector3 targetPosition;
    private GameObject player, ship1, ship2, ship3, ship4, cameraShake;
    public GameObject attackPoints, basicPoints;
    private Transform pointsSpawn;
    public bool nearColonyShip;
    private bool sound, anim;
    public GameObject colonyShip;
    public Sprite attackPlayer;
    public AnimationClip attackPlayerAnim;
    public Animator animController;
    public SoundEffectsController swarmController;

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
        animController = GetComponent<Animator>();
        swarmController = GetComponent<SoundEffectsController>();
    }

    // Update is called once per frame
    void Update()
    {
        float step = moveSpeed * Time.deltaTime;
        if (target == 0) //player is target
        {
            animController.SetBool("Player", true);
            targetPosition = player.transform.position;
            gameObject.GetComponent<SpriteRenderer>().sprite = attackPlayer;
            gameObject.GetComponent<Animation>().clip = attackPlayerAnim;
        }
        else //ship is target
        {
            ChooseShip();
        }

        Vector3 toTarget = targetPosition - transform.position;

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
        transform.up = targetPosition - transform.position;
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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player();
        }
        else if (collision.gameObject.tag == "Bullet")
        {
            Bullet();
        }
        else if (collision.gameObject.tag == "Meteor")
        {
            Meteor();
        }
        else if (collision.gameObject.tag == "Ship")
        {
            collision.gameObject.GetComponent<ColonyShipScript>().health -= 1;
            collision.gameObject.GetComponent<ColonyShipScript>().UpdateHealth();
            Ship();
        }
        else if (collision.gameObject.tag == "Swarm")
        {
            Vector3 dist = transform.position - collision.gameObject.transform.position;
            Swarm(dist);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            Player();
        }
        else if (col.tag == "Bullet")
        {
            Bullet();
        }
        else if (col.tag == "Meteor")
        {
            Meteor();
        }
        else if (col.tag == "Ship")
        {
            col.GetComponent<ColonyShipScript>().health -= 1;
            col.GetComponent<ColonyShipScript>().UpdateHealth();
            Ship();
        }
        else if(col.tag == "Swarm")
        {
            Vector3 dist = transform.position - col.transform.position;
            Swarm(dist);
        }
    }

    IEnumerator Explosion()
    {
        //anim.Play("Explosion");
        if (sound)
            swarmController.PlayEffect("Explosion", false, 0.15f); //play explosion sound

        gameObject.GetComponents<Collider2D>()[0].enabled = false;
        gameObject.GetComponents<Collider2D>()[1].enabled = false;
        if (anim)
        {
            animController.SetBool("dead", true);
            yield return new WaitForSeconds(0.5f);
        }
        sound = false;
        anim = false;
        Destroy(gameObject);
    }

    void Player()
    {
        sound = true;
        anim = false;
        player.GetComponent<PlayerScript>().DamageHealth(1);
        cameraShake.GetComponent<CameraShake>().Shake();
        if (nearColonyShip && colonyShip.GetComponent<ShipRadarScript>().threatLevel > 0)
        {
            colonyShip.GetComponent<ShipRadarScript>().threatLevel -= 1;
        }
        StartCoroutine(Explosion());
    }

    void Bullet()
    {
        //swarmController.PlayEffect("Explosion", false, 0.15f); //play explosion sound
        sound = true;
        anim = true;
        if (target == 0)
        {
            GameManager.singleton.ChangeScore(25);
            GameManager.singleton.ItemDrop(2, gameObject);
        }
        else
        {
            GameManager.singleton.ChangeScore(10);
            GameManager.singleton.ItemDrop(1, gameObject);
        }

        ShowPoints();

        if (nearColonyShip && colonyShip.GetComponent<ShipRadarScript>().threatLevel > 0)
        {
            colonyShip.GetComponent<ShipRadarScript>().threatLevel -= 1;
        }

        StartCoroutine(Explosion());
    }

    void Meteor()
    {
        anim = true;
        sound = false;
        if (nearColonyShip && colonyShip.GetComponent<ShipRadarScript>().threatLevel > 0)
        {
            colonyShip.GetComponent<ShipRadarScript>().threatLevel -= 1;
        }
        StartCoroutine(Explosion());
    }

    void Ship()
    {
        anim = true;
        sound = false;
        if (nearColonyShip && colonyShip.GetComponent<ShipRadarScript>().threatLevel > 0)
        {
            colonyShip.GetComponent<ShipRadarScript>().threatLevel -= 1;
        }
        StartCoroutine(Explosion());
    }

    void Swarm(Vector3 dist)
    {
        transform.position += dist * Time.deltaTime;
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
