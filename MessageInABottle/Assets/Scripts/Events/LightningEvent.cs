using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningEvent : GameEvent
{
    private int hits;

    [SerializeField] private int hitsToKill;

    [SerializeField] private float timeToKill;

    private bool startTimer;

    private float timer;

    private TimeBarController tbc;
    // Start is called before the first frame update
    void Start()
    {
        tbc = GameObject.FindWithTag("Player").GetComponent<TimeBarController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer)
        {
            tbc.SetTimerValue(timer / timeToKill);
            
            if (Input.GetKeyDown(KeyCode.Space))
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

            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                trigger.Fail();
                startTimer = false;
                tbc.ShowTimer(0);
            }
        }
    }

    public override void SpawnEvent(BottleEvent eventTrigger)
    {
        startTimer = true;
        timer = timeToKill;
        base.SpawnEvent(eventTrigger);

        tbc.ShowTimer(1);

        transform.GetChild(0).gameObject.SetActive(true);
    }

    private void OnMouseUpAsButton()
    {
        
    }
}