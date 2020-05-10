using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
    PlayerScript ps;

    // Start is called before the first frame update
    void Start()
    {
        ps = GameObject.Find("Player").GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            if (!ps.hasPowerUp)
            {
                ps.ActivatePowerUp(gameObject.name);
                GameManager.singleton.itemMaxCounter--;
                Destroy(gameObject);
                Debug.Log("Subtract to: " + GameManager.singleton.itemMaxCounter);
            }
            else
            {

            }
        }
        else
        {

        }
    }
}
