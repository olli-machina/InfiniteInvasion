using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public float health = 10, maxHealth = 10,
        shotgunTimer, doubleShotTimer, fullDirectionalTimer;
    public GameObject[] healthWedges;
    public GameObject[] damageWedges;
    public GameObject healthOrb;
    public GameObject damageOrb;
    public bool inRepair = false, hasPowerUp = false;
    private bool doubleShot = false, shotgun = false, fullDirectional = false;
    public GameObject bulletPrefab;
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
                healthWedges[(int)health].SetActive(true);
                damageWedges[(int)health].SetActive(false);
                health += 1f;
            }
            else
            {
                CheckWeapon();
                GameObject bullet = Instantiate(bulletPrefab, fireLocation.position, fireLocation.rotation) as GameObject;
            }
        }

        /*
        if (Input.GetKeyUp("space"))
        {
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
            if (inRepair)
                health += 0.5f;
        */
        
        if (health >= 10)
        {
            health = 10;
            inRepair = false;
            GetComponent<PlayerMovement>().enabled = true;
            healthOrb.SetActive(true);
            damageOrb.SetActive(false);
        }
    }

    public void DamageHealth(float damage)
    {
        if (health > 0)
        {
            health -= damage;
            healthWedges[(int)health].SetActive(false);
            damageWedges[(int)health].SetActive(true);
            //StartCoroutine(flashRed());
        }
        else if (health <= 0)
        {
            health = 0;
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
            damageOrb.SetActive(true);
            healthOrb.SetActive(false);
            inRepair = true;
            ForceRepair();
        }
    }

    IEnumerator PowerUpTimer(float time, bool powerUp)
    {
        powerUp = true;
        yield return new WaitForSeconds(time);
        powerUp = false;
        hasPowerUp = false;
    }

    public void CheckWeapon()
    {
        if (doubleShot)
        {
            Debug.Log("DoubleShot");
        }
        else if (shotgun)
        {
            Debug.Log("Shotgun");
        }
        else if (fullDirectional)
        {
            Debug.Log("FD");
        }
        else
        {
            GameObject bullet = Instantiate(bulletPrefab, fireLocation.position, fireLocation.rotation) as GameObject;
        }
    }

    public void ActivatePowerUp(string name)
    {
        if (!hasPowerUp)
        {
            hasPowerUp = true;
            switch (name)
            {
                case "DoubleShot":
                    StartCoroutine(PowerUpTimer(doubleShotTimer, doubleShot));
                    break;
                case "Shotgun":
                    StartCoroutine(PowerUpTimer(shotgunTimer, shotgun));
                    break;
                case "FullDirectional":
                    StartCoroutine(PowerUpTimer(fullDirectionalTimer, fullDirectional));
                    break;

            }
        }
    }

}


