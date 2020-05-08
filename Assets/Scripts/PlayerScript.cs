using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public float health = 10, maxHealth = 10;
    public HealthBar healthUI;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DamageHealth(float damage)
    {
        health -= damage;
        healthUI.decreaseValue(health / maxHealth);
        StartCoroutine(flashRed());
    }

    IEnumerator flashRed()
    {
        gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        yield return new WaitForSeconds(.25f);
        gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
    }

}
