using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager singleton;

    private GameObject Player, Meteor;
    public GameObject mPrefab1, mPrefab2, mPrefab3, mPrefab4, mPrefab5, SwarmMember, SwarmParent, MeteorParent,
        shotgun, doubleshot, fulldirectional;
    Transform swarmSpawn, meteorSpawn;
    Vector3 position;
    private int shipCounter = 0, itemCounter = 0;
    public int score, randShipNumber = 0, randomTime, shipsLeft = 4;
    private float spawnTimer = 0.0f, shipTimer = 0.0f, randShipDuration = 20.0f;
    private GameObject scoreTextObject;
    private Text scoreText;
    public Vector3 spawnPoint1 = new Vector3(1.9f, -1.72f, 0.0f),
                    spawnPoint2 = new Vector3(0.58f, -2.74f, 0.0f),
                    spawnPoint3 = new Vector3(0.97f, 0.23f, 0.0f),
                    spawnPoint4 = new Vector3(2.32f, -0.13f, 0.0f),
                    spawnPoint5 = new Vector3(1.54f, -1.24f, 0.0f),
                    spawnPoint6 = new Vector3(-0.2f, -0.64f, 0.0f),
                    spawnPoint7 = new Vector3(-1.79f, -0.79f, 0.0f),
                    spawnPoint8 = new Vector3(-0.41f, 0.5f, 0.0f),
                    spawnPoint9 = new Vector3(-1.22f, 2.03f, 0.0f),
                    spawnPoint10 = new Vector3(1.08f, 2.12f, 0.0f);
    public List<int> highScores;
    public bool setScore = false;

    void Awake()
    {
        if (singleton == null)
        {
            //DontDestroyOnLoad(gameObject);
            singleton = this;
        }

        else if(singleton != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreTextObject = GameObject.Find("Score");
        scoreText = scoreTextObject.GetComponent<Text>();
        Player = GameObject.Find("Player");
        swarmSpawn = SwarmParent.transform;
        meteorSpawn = MeteorParent.transform;
        randomTime = UnityEngine.Random.Range(0, 2);
        if(randomTime == 0)
            randShipDuration = 60f;
        else
            randShipDuration = 30f;

        randShipNumber = 0;

        LoadScores();
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        shipTimer += Time.deltaTime;
        if(spawnTimer >= 5.0f)
        {
            if (SceneManager.GetActiveScene().name == "SampleScene")
            SpawnSwarm();
            spawnTimer = 0.0f;
        }
        if(shipTimer >= randShipDuration)
        {
            randomTime = UnityEngine.Random.Range(0, 2);
            if (randomTime == 0)
                randShipDuration = 15.0f;
            else
                randShipDuration = 30.0f;

            randShipNumber = UnityEngine.Random.Range(0, 4);
            shipTimer = 0.0f;
        }

        if (shipsLeft <= 0)
        {
            if (setScore == false)
            {
                setScore = true;
                SceneManager.LoadScene("EndScreen");
                CheckScores();
            }
        }
    }

    public void ItemDrop(int points)
    {
        itemCounter += points;
        if(itemCounter >= 10)
        {
            var randomDrop = UnityEngine.Random.Range(0, 2);
            if (randomDrop == 0)
                   itemCounter = 0;
            else
            {
                var randomChance = UnityEngine.Random.Range(0, 100);
                if (randomChance < 5) //5% chance enemy drops full directional
                {
                    var FD = Instantiate(fulldirectional, gameObject.transform.position, Quaternion.identity);
                    FD.name = "FullDirectional";
                }
                else if (randomChance < 10) //10% chance enemy drops shotgun
                {
                    var SG = Instantiate(shotgun, gameObject.transform.position, Quaternion.identity);
                    SG.name = "Shotgun";
                }
                else if (randomChance < 25) //25% chance enemy drops double shot
                {
                    var DS = Instantiate(doubleshot, gameObject.transform.position, Quaternion.identity);
                    DS.name = "DoubleShot";
                }
            }
        }
    }

    public void ChangeScore(int addPoints)
    {
        score += addPoints;

        scoreText.text = score.ToString();
    }

    public void SpawnMeteor()
    {
        var rL = UnityEngine.Random.Range(0, 2);
        if(rL == 0)
            position = new Vector3(UnityEngine.Random.Range(-41.0f, -32.0f), UnityEngine.Random.Range(-31.0f, 31.0f), 0);
        else
            position = new Vector3(UnityEngine.Random.Range(32.0f, 37.0f), UnityEngine.Random.Range(-31.0f, 31.0f), 0);

        var meteorSprite = UnityEngine.Random.Range(0, 4);
        if (meteorSprite == 0)
            Meteor = mPrefab1;
        else if (meteorSprite == 1)
            Meteor = mPrefab2;
        else if (meteorSprite == 2)
            Meteor = mPrefab3;
        else if (meteorSprite == 3)
            Meteor = mPrefab4;
        else if (meteorSprite == 4)
            Meteor = mPrefab5;

        Instantiate(Meteor, position, Quaternion.identity, meteorSpawn);
    }

    public void SpawnSwarm()
    {
        Instantiate(SwarmMember, spawnPoint1, Quaternion.identity, swarmSpawn);
        Instantiate(SwarmMember, spawnPoint2, Quaternion.identity, swarmSpawn);
        Instantiate(SwarmMember, spawnPoint3, Quaternion.identity, swarmSpawn);
        Instantiate(SwarmMember, spawnPoint4, Quaternion.identity, swarmSpawn);
        Instantiate(SwarmMember, spawnPoint5, Quaternion.identity, swarmSpawn);
        Instantiate(SwarmMember, spawnPoint6, Quaternion.identity, swarmSpawn);
        Instantiate(SwarmMember, spawnPoint7, Quaternion.identity, swarmSpawn);
        Instantiate(SwarmMember, spawnPoint8, Quaternion.identity, swarmSpawn);
        Instantiate(SwarmMember, spawnPoint9, Quaternion.identity, swarmSpawn);
        Instantiate(SwarmMember, spawnPoint10, Quaternion.identity, swarmSpawn);
    }

    public void CheckScores()
    {
        for (int i = 0; i <= 9; i++)
        {
            if (score > highScores[i])
            {
                highScores.Insert(i, score);
                highScores.Remove(10);
                break;
            }
        }

        SaveScores();
    }

    public void SaveScores()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/highScores.dat");

        HighScores data = new HighScores();
        data.highScores = new int[10];
        for (int i = 0; i <=9; i++)
        {
            data.highScores[i] = highScores[i];
        }

        bf.Serialize(file, data);
        file.Close();
    }

    public void LoadScores()
    {
        if(File.Exists(Application.persistentDataPath + "/highScores.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/highScores.dat", FileMode.Open);
            HighScores data = (HighScores)bf.Deserialize(file);
            file.Close();

            highScores = new List<int>(10);
            highScores.Add(data.highScores[0]);
            highScores.Add(data.highScores[1]);
            highScores.Add(data.highScores[2]);
            highScores.Add(data.highScores[3]);
            highScores.Add(data.highScores[4]);
            highScores.Add(data.highScores[5]);
            highScores.Add(data.highScores[6]);
            highScores.Add(data.highScores[7]);
            highScores.Add(data.highScores[8]);
            highScores.Add(data.highScores[9]);
        }
    }
}

[Serializable]
class HighScores
{
    public int[] highScores;
}
