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
    private bool doubleShot = false, shotgun = false, fullDirectional = false, invunerable = false;
    public GameObject bulletPrefab, UIFD, UIDS, UISG, UIS;
    private GameObject cameraShake;
    Transform fireLocation;
    FireBullet fireRange;

    // Start is called before the first frame update
    void Start()
    {
        fireLocation = transform.Find("BulletSpawn");
        cameraShake = GameObject.Find("Main Camera");
        fireRange = GetComponentInChildren<FireBullet>();
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
            }
        }

        if (inRepair)
        {
            invunerable = true;
        }

        if (health >= 10)
        {
            SetFixed();
        }
    }

    public void SetFixed()
    {
        health = 10;
        inRepair = false;
        invunerable = false;
        GetComponent<PlayerMovement>().enabled = true;
        healthOrb.SetActive(true);
        damageOrb.SetActive(false);
    }

    public void FullHeal()
    {
        for (int i = 0; i < healthWedges.Length; i++)
        {
            healthWedges[i].SetActive(true);
            damageWedges[i].SetActive(false);
        }
        health = 10;
        inRepair = false;
    }

    public void DamageHealth(float damage)
    {
        if (health > 0)
        {
            if (!invunerable)
            {
                health -= damage;
                healthWedges[(int)health].SetActive(false);
                damageWedges[(int)health].SetActive(true);
            }
            //StartCoroutine(flashRed());
        }
        else if (health <= 0)
        {
            health = 0;
            damageOrb.SetActive(true);
            healthOrb.SetActive(false);
            inRepair = true;
            ForceRepair();
            //Debug.Log("Repairing" + inRepair);
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
            if (!invunerable)
            {
                health = 0;
                for (int i = 9; i >= 0; i--)
                {
                    healthWedges[i].SetActive(false);
                    damageWedges[i].SetActive(true);
                }
            }
            damageOrb.SetActive(true);
            healthOrb.SetActive(false);
            inRepair = true;
            ForceRepair();
        }
    }

    IEnumerator PowerUpTimer(float time, int powerUp)
    {
        UIS.SetActive(false);
        switch (powerUp)
        {
            case 0:
                doubleShot = true;
                UIDS.SetActive(true);
                break;
            case 1:
                shotgun = true;
                UISG.SetActive(true);
                break;
            case 2:
                fullDirectional = true;
                UIFD.SetActive(true);
                break;
        }

        yield return new WaitForSeconds(time);
        switch (powerUp)
        {
            case 0:
                doubleShot = false;
                UIDS.SetActive(false);
                break;
            case 1:
                shotgun = false;
                UISG.SetActive(false);
                break;
            case 2:
                fullDirectional = false;
                UIFD.SetActive(false);
                break;
        }
        hasPowerUp = false;
        UIS.SetActive(true);
    }

    public void CheckWeapon()
    {
        Quaternion newRotation = Quaternion.identity;
        if (doubleShot)
        {
            fireRange.DoubleShot();
        }
        else if (shotgun)
        {
            fireRange.Shotgun();
        }
        else if(fullDirectional)
        {
            fireRange.FullDirection();
        }
        else
        {
            fireRange.Fire();
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


