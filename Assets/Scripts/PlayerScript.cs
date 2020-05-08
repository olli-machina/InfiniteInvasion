using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public float health = 10, maxHealth = 10;
    public HealthBar healthUI;
    public bool inRepair = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("space"))
            health += 0.025f;
        if (Input.GetKeyDown("space"))
        {
            health += 0.5f;  
        }

        if (health > 10)
            health = 10;
        healthUI.decreaseValue(health / maxHealth);
    }

    public void DamageHealth(float damage)
    {
        health -= damage;
        healthUI.decreaseValue(health / maxHealth);
        StartCoroutine(flashRed());
        if (health <= 3.0)
        {
            ForceRepair();
        }
    }

    public void ForceRepair()
    {
        //stop firing
        if(health >= 3.5)
            inRepair = false;
    }

    IEnumerator flashRed()
    {
        gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        yield return new WaitForSeconds(.25f);
        gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Meteor")
        {
            health = 2;
            inRepair = true;
            ForceRepair();
        }
    }

}
