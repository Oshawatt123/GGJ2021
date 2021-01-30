﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkEvent : GameEvent
{
    private int hits;

    [SerializeField] private int hitsToKill;

    [SerializeField] private float timeToKill;


    private bool startTimer;

    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                trigger.Fail();
            }
        }
    }

    public override void SpawnEvent(BottleEvent eventTrigger)
    {
        startTimer = true;
        timer = timeToKill;
        base.SpawnEvent(eventTrigger);
    }

    private void OnMouseUpAsButton()
    {
        hits++;

        if (hits > hitsToKill)
        {
            trigger.Pass();
        }
    }
}
