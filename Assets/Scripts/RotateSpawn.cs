using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSpawn : MonoBehaviour
{
    private Quaternion player;

    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponentInParent<Transform>().rotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = player;
    }
}
