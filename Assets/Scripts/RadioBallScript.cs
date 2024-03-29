﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioBallScript : MonoBehaviour
{
    Animator anim;
    public SoundEffectsController radioController;

    // Start is called before the first frame update
    void Start()
    {
        radioController = GetComponent<SoundEffectsController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncomingMessage()
    {
        radioController.PlayEffect("Radio", false, 0.5f); //play radio sound
        anim.Play("RadioIncoming");
    }

    public void EndMessage()
    {
        anim.Play("RadioDefault");
        radioController.StopEffect("Radio");
    }
}
