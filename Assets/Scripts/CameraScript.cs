using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private Transform player;
    public float xMargin = 1f, yMargin = 1f, xSmooth = 8f, ySmooth = 8f;
    public float xBounds = 20.0f, yBounds = 20.0f;
    public Vector2 minBounds, maxBounds;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        float targetX = transform.position.x;
        float targetY = transform.position.y;
        if (CheckX())
            targetX = Mathf.Lerp(transform.position.x, player.position.x, xSmooth * Time.deltaTime);

        if (CheckY())
            targetY = Mathf.Lerp(transform.position.y, player.position.y, ySmooth * Time.deltaTime);

        targetX = Mathf.Clamp(targetX, minBounds.x, maxBounds.x);
        targetY = Mathf.Clamp(targetY, minBounds.y, maxBounds.y);

        transform.position = new Vector3(targetX, targetY, transform.position.z);
    }

    public bool CheckX()
    {
        return Mathf.Abs(transform.position.x - player.position.x) > xMargin;
    }

    public bool CheckY()
    {
        return Mathf.Abs(transform.position.y - player.position.y) > yMargin;
    }
}
