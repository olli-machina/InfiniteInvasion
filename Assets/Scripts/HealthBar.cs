using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider healthBar;
    private Color midColor = Color.yellow, endColor = Color.red, fullColor = Color.green;

    public float fillSpeed = 0.5f;
    private float targetProgress = 1;
    bool repair = false;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = gameObject.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {

        if (healthBar.value > targetProgress)
            healthBar.value -= fillSpeed * Time.deltaTime;

        if (repair)
            increaseValue();
    }

    public void increaseValue()
    {
        if (healthBar.value < targetProgress)
            healthBar.value += fillSpeed * Time.deltaTime;
        else
            repair = false;
    }

    public bool decreaseValue(float takeHealth)
    {
        if (takeHealth > targetProgress)
            repair = true;
        targetProgress = takeHealth;

        if (targetProgress <= 0)
            return true;

        else if (targetProgress <= .25f)
            healthBar.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = endColor;

        else if (targetProgress <= .5f)
            healthBar.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = midColor;
        else
            healthBar.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = fullColor;

        return false;
    }

    //public void increaseValue(float giveHealth)
    //{
    //    targetProgress = giveHealth;
    //    if (targetProgress > 1)
    //        targetProgress = 1;

    //    else if (targetProgress <= .25f)
    //        healthBar.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = endColor;

    //    else if (targetProgress <= .5f)
    //        healthBar.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = midColor;
    //    else
    //        healthBar.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = fullColor;
    //}
}
