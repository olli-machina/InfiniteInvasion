using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{

    public GameObject bulletPrefab, bulletParent;
    private Transform bulletSpawn;
    public Transform[] spawnLoc;

    // Start is called before the first frame update
    void Start()
    {
        bulletSpawn = bulletParent.transform;
        spawnLoc = new Transform[13];
        for(int i = 0; i < 13; i++)
        {
            spawnLoc[i] = GetComponentsInChildren<Transform>()[i];
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DoubleShot()
    {
        GameObject bullet = Instantiate(bulletPrefab, spawnLoc[2].position, transform.rotation, bulletSpawn) as GameObject; //offset left
        GameObject dbullet = Instantiate(bulletPrefab, spawnLoc[3].position, transform.rotation, bulletSpawn) as GameObject; //offset right
    }

    public void Shotgun()
    {
        GameObject bullet = Instantiate(bulletPrefab, spawnLoc[2].position, transform.rotation, bulletSpawn) as GameObject; //offset left
        bullet.transform.Rotate(0f, 0f, 5.0f);

        GameObject dbullet = Instantiate(bulletPrefab, spawnLoc[3].position, transform.rotation, bulletSpawn) as GameObject; //offset right
        dbullet.transform.Rotate(0f, 0f, -5.0f);

        GameObject tbullet = Instantiate(bulletPrefab, spawnLoc[4].position, transform.rotation, bulletSpawn) as GameObject; //offset left x2
        tbullet.transform.Rotate(0f, 0f, 10.0f);

        GameObject qbullet = Instantiate(bulletPrefab, spawnLoc[5].position, transform.rotation, bulletSpawn) as GameObject; //offset right x2
        qbullet.transform.Rotate(0f, 0f, -10.0f);
    }

    public void FullDirection()
    {
        GameObject ubullet = Instantiate(bulletPrefab, spawnLoc[6].position, transform.rotation, bulletSpawn) as GameObject; //southwest
        ubullet.transform.Rotate(0f, 0f, 135.0f);

        GameObject qbullet = Instantiate(bulletPrefab, spawnLoc[7].position, transform.rotation, bulletSpawn) as GameObject; //west
        qbullet.transform.Rotate(0f, 0f, 90.0f);

        GameObject qubullet = Instantiate(bulletPrefab, spawnLoc[8].position, transform.rotation, bulletSpawn) as GameObject; //northwest
        qubullet.transform.Rotate(0f, 0f, 45.0f);

        GameObject bullet = Instantiate(bulletPrefab, spawnLoc[1].position, transform.rotation, bulletSpawn) as GameObject; //north

        GameObject sbullet = Instantiate(bulletPrefab, spawnLoc[9].position, transform.rotation, bulletSpawn) as GameObject; //northeast
        sbullet.transform.Rotate(0f, 0f, -45.0f);

        GameObject tbullet = Instantiate(bulletPrefab, spawnLoc[10].position, transform.rotation, bulletSpawn) as GameObject; //east
        tbullet.transform.Rotate(0f, 0f, -90.0f);

        GameObject vbullet = Instantiate(bulletPrefab, spawnLoc[11].position, transform.rotation, bulletSpawn) as GameObject; //southeast
        vbullet.transform.Rotate(0f, 0f, -135.0f);

        GameObject dbullet = Instantiate(bulletPrefab, spawnLoc[12].position, transform.rotation, bulletSpawn) as GameObject; //south
        dbullet.transform.Rotate(0f, 0f, 180.0f);
    }

    public void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, spawnLoc[1].position, transform.rotation, bulletSpawn) as GameObject; //north

    }

}