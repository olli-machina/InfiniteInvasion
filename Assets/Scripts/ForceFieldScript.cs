using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceFieldScript : MonoBehaviour
{
    public Transform meteor;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.Play("ForceField");
    }

    // Update is called once per frame
    void Update()
    {
        transform.up = meteor.transform.position - transform.position;
    }

    void DestroyForceField()
    {
        Destroy(gameObject);
    }
}
