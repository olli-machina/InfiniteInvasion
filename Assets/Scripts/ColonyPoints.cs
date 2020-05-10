using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColonyPoints : MonoBehaviour
{
    public GameObject points, pointsParent;
    private Transform pointsSpawn;
    private Vector3 pointsTransform;
    private float shipTimer = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        pointsTransform = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 1);
        pointsSpawn = pointsParent.transform;
    }

    // Update is called once per frame
    void Update()
    {
        shipTimer += Time.deltaTime;
        if(shipTimer >= 5.0f)
        {
            GameManager.singleton.ChangeScore(100);
            ShowPoints();
            shipTimer = 0.0f;
        }
    }

    void ShowPoints()
    {
        Instantiate(points, pointsTransform, Quaternion.identity, pointsSpawn);
    }
}
