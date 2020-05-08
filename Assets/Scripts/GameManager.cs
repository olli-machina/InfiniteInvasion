using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject Player;
    public GameObject Meteor;//, SwarmMember;
    Vector3 position;
    private int shipCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnMeteor()
    {
        var rL = Random.Range(0, 2);
        if(rL == 0)
            position = new Vector3(Random.Range(-41.0f, -32.0f), Random.Range(-31.0f, 31.0f), 0);
        else
            position = new Vector3(Random.Range(32.0f, 37.0f), Random.Range(-31.0f, 31.0f), 0);

        Instantiate(Meteor, position, Quaternion.identity);
    }

    public int SetShip()
    {
        if (shipCounter > 100)
        {
            shipCounter = 0;
            return 4;
        }
        else if (shipCounter > 75)
            return 3;
        else if (shipCounter > 50)
            return 2;
        else
            return 1;
    }
}
