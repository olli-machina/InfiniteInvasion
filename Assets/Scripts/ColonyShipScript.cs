using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColonyShipScript : MonoBehaviour
{
    public float health = 10;
    public float maxHealth = 10;
    public HealthBar healthUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            GameManager.singleton.shipsLeft -= 1;
            GetComponent<ShipRadarScript>().message.SetActive(false);
            GetComponent<ShipRadarScript>().messageBorder.SetActive(false);
            Destroy(gameObject);
        }
    }

    public void UpdateHealth()
    {
        healthUI.decreaseValue(health / maxHealth);
    }
}
