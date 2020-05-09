using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public float health = 10, maxHealth = 10;
    public HealthBar healthUI;
    public GameObject[] healthWedges;
    public GameObject[] damageWedges;
    public GameObject healthOrb;
    public GameObject damageOrb;
    public bool inRepair = false;
    public GameObject bullet;
    private GameObject cameraShake;
    Transform fireLocation;

    // Start is called before the first frame update
    void Start()
    {
        fireLocation = transform.Find("BulletSpawn");
        cameraShake = GameObject.Find("Main Camera");
        for (int i = 9; i >= 0; i--)
        {
            damageWedges[i].SetActive(false);
        }
        damageOrb.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (inRepair)
            {
                health += 0.5f;
                gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
            }
            else
            {
                Instantiate(bullet, fireLocation.position, fireLocation.rotation);
            }
        }

        /*
        if (Input.GetKeyUp("space"))
        {
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
            if (inRepair)
                health += 0.5f;
        */
        
        if (health > 10)
        {
            health = 10;
            inRepair = false;
            GetComponent<PlayerMovement>().enabled = true;
        }

        healthUI.decreaseValue(health / maxHealth);
    }

    public void DamageHealth(float damage)
    {
        if (health > 0)
        {
            health -= damage;
            healthWedges[(int)health].SetActive(false);
            damageWedges[(int)health].SetActive(true);
            healthUI.decreaseValue(health / maxHealth);
            StartCoroutine(flashRed());
        }
        if (health <= 0)
        {
            damageOrb.SetActive(true);
            healthOrb.SetActive(false);
            inRepair = true;
            ForceRepair();
            Debug.Log("Repairing" + inRepair);
        }
    }

    public void ForceRepair()
    {
        GetComponent<PlayerMovement>().enabled = false;
        
        //stop firing
        if(health >= 10)
        {
            inRepair = false;
            GetComponent<PlayerMovement>().enabled = true;
        }
    }

    IEnumerator flashRed()
    {
        healthOrb.SetActive(false);
        damageOrb.SetActive(true);
        yield return new WaitForSeconds(.25f);
        healthOrb.SetActive(true);
        damageOrb.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Meteor")
        {
            cameraShake.GetComponent<CameraShake>().Shake();
            health = 0;
            for (int i = 9; i >= 0; i--)
            {
                healthWedges[i].SetActive(false);
                damageWedges[i].SetActive(true);
            }
            inRepair = true;
            ForceRepair();
        }
    }

}
