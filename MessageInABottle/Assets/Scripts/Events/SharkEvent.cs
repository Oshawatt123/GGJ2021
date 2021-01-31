using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SharkEvent : GameEvent
{
    private int hits;

    [SerializeField] private int hitsToKill;

    [SerializeField] private float timeToKill;

    private bool startTimer;

    private float timer;

    private TimeBarController tbc;

    [SerializeField] private Slider health1;
    [SerializeField] private Slider health2;
    // Start is called before the first frame update
    void Start()
    {
        tbc = GameObject.FindWithTag("Player").GetComponent<TimeBarController>();
    }

    // Update is called once per frame
    void Update()
    {
        health1.value = (hitsToKill-hits)/(float)hitsToKill;
        health2.value = (hitsToKill-hits)/(float)hitsToKill;
        
        if (startTimer)
        {
            tbc.SetTimerValue(timer / timeToKill);
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                trigger.Fail();
                tbc.ShowTimer(0);
                startTimer = false;
            }
        }
    }

    public override void SpawnEvent(BottleEvent eventTrigger)
    {
        startTimer = true;
        timer = timeToKill;
        tbc.ShowTimer(1);
        base.SpawnEvent(eventTrigger);
        transform.position = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
    }

    private void OnMouseUpAsButton()
    {
        hits++;

        if (hits > hitsToKill)
        {
            transform.position = new Vector3(0, -10, 0);
            trigger.Pass();
            startTimer = false;
            tbc.ShowTimer(0);
        }
    }
}
