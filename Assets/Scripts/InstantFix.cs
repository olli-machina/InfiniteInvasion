using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantFix : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            if(player.GetComponent<PlayerScript>().health < 10)
            {
                player.GetComponent<PlayerScript>().FullHeal();
                Destroy(gameObject);
            }
        }
        else
        {

        }
    }

}
