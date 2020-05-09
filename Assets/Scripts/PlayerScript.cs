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
    private bool doubleShot = false, shotgun = true, fullDirectional = false;
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
        if (Input.GetKeyDown("space") || Input.GetButtonDown("Fire1"))
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
                //GameObject bullet = Instantiate(bulletPrefab, fireLocation.position, fireLocation.rotation) as GameObject;
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

    IEnumerator PowerUpTimer(float time, int powerUp)
    {
        switch(powerUp)
        {
            case 0:
                doubleShot = true;
                break;
            case 1:
                shotgun = true;
                break;
            case 2:
                fullDirectional = true;
                break;
        }
        Debug.Log(doubleShot);
        yield return new WaitForSeconds(time);
        switch (powerUp)
        {
            case 0:
                doubleShot = false;
                break;
            case 1:
                shotgun = false;
                break;
            case 2:
                fullDirectional = false;
                break;
        }
        hasPowerUp = false;
    }

    public void CheckWeapon()
    {
        if (doubleShot)
        {
            GameObject bullet = Instantiate(bulletPrefab, new Vector3((fireLocation.position.x + 0.5f), fireLocation.position.y, fireLocation.position.z), fireLocation.rotation) as GameObject;
            GameObject dbullet = Instantiate(bulletPrefab, new Vector3((fireLocation.position.x - 0.5f), fireLocation.position.y, fireLocation.position.z), fireLocation.rotation) as GameObject;
        }
        else if (shotgun)
        {
            Debug.Log("Shotgun");
            GameObject bullet = Instantiate(bulletPrefab, new Vector3((fireLocation.position.x + 0.5f), fireLocation.position.y, fireLocation.position.z), fireLocation.rotation) as GameObject;
            GameObject dbullet = Instantiate(bulletPrefab, new Vector3((fireLocation.position.x - 0.5f), fireLocation.position.y, fireLocation.position.z), fireLocation.rotation) as GameObject;
            GameObject tbullet = Instantiate(bulletPrefab, new Vector3((fireLocation.position.x + 1.0f), (fireLocation.position.y), fireLocation.position.z), 
                Quaternion.Euler(fireLocation.rotation.x, fireLocation.rotation.y, (fireLocation.rotation.z - 10.0f))) as GameObject;
            GameObject qbullet = Instantiate(bulletPrefab, new Vector3((fireLocation.position.x - 1.0f), (fireLocation.position.y), fireLocation.position.z),
                Quaternion.Euler(fireLocation.rotation.x, fireLocation.rotation.y, (fireLocation.rotation.z + 10.0f))) as GameObject;
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
                    StartCoroutine(PowerUpTimer(doubleShotTimer, 0));
                    break;
                case "Shotgun":
                    StartCoroutine(PowerUpTimer(shotgunTimer, 1));
                    break;
                case "FullDirectional":
                    StartCoroutine(PowerUpTimer(fullDirectionalTimer, 2));
                    break;

            }
        }
    }

}


