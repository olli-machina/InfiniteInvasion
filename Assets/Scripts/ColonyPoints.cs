using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColonyPoints : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject points;
    private Vector3 pointsTransform;
    private float shipTimer = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        pointsTransform = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 1);
    }

    // Update is called once per frame
    void Update()
    {
        shipTimer += Time.deltaTime;
        if(shipTimer >= 5.0f)
        {
            gameManager.ChangeScore(100);
            ShowPoints();
            shipTimer = 0.0f;
        }
    }

    void ShowPoints()
    {
        Instantiate(points, pointsTransform, Quaternion.identity);
    }
}
