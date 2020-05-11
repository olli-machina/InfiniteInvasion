using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PlayerMenuScript : MonoBehaviour
{
    GameObject currentSelected;
    private Vector3 targetPos;
    private float speed = 10;
    private float timer, timeToMove = 1.0f, timerSpeed = 1.0f, xPos;

    // Start is called before the first frame update
    void Start()
    {
        xPos = 150;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime * timerSpeed;
        if (timer >= timeToMove)
        {
            xPos = transform.position.x + Random.Range(-20f, 20f);
            timer = 0.0f;
        }

        currentSelected = EventSystem.current.currentSelectedGameObject;
        targetPos = new Vector3(xPos, currentSelected.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPos, speed * Time.deltaTime);
    }
}
