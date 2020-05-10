using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private Transform player;
    public float xMargin = 1f, yMargin = 1f, smooth = 8f;//xSmooth = 8f, ySmooth = 8f;
    public float xBounds = 20.0f, yBounds = 20.0f, moveSpeed = 30.0f;
    public Vector2 minBounds, maxBounds, pm;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        pm = player.GetComponent<PlayerMovement>().newVelocity;
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
        float step = moveSpeed * Time.fixedDeltaTime;
        Vector2 target = transform.position;
        //float targetX = transform.position.x;
        //float targetY = transform.position.y;
        if (CheckX() || CheckY())
            target = Vector2.Lerp(transform.position, player.position,step);// ref pm, smooth * Time.fixedDeltaTime);  //xSmooth * Time.deltaTime);

        //if (CheckY())
        //    targetY = Vector2.SmoothDamp(transform.position.y, player.position.y, ref pm.y, smooth);

        target.x = Mathf.Clamp(target.x, minBounds.x, maxBounds.x);
        target.y = Mathf.Clamp(target.y, minBounds.y, maxBounds.y);

        transform.position = new Vector3(target.x, target.y, transform.position.z);
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
