using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float bulletSpeed = 5f;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        GetComponent<Rigidbody2D>().AddForce(transform.up * bulletSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Swarm")
        {
            Destroy(col);
            Destroy(gameObject);
            gameManager.ChangeScore(10);
        }
        if (col.tag == "Bounds")
            Destroy(gameObject);
    }

}
