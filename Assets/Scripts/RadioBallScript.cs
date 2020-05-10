using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioBallScript : MonoBehaviour
{
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncomingMessage()
    {
        anim.Play("RadioIncoming");
    }

    public void EndMessage()
    {
        anim.Play("RadioDefault");
    }
}
