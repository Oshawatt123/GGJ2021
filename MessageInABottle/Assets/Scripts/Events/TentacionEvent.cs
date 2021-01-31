using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacionEvent : GameEvent
{
    [SerializeField] private float timeToKill;

    private bool startTimer;

    private float timer;

    private List<Tentacle> tentacles = new List<Tentacle>();
    private int completed;

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
    }

    public void Subscribe(Tentacle tentacle)
    {
        tentacles.Add(tentacle);
    }

    public void CompleteTent()
    {
        completed += 1;

        if (completed >= tentacles.Count)
        {
            trigger.Pass();
            startTimer = false;
            tbc.ShowTimer(0);
        }
    }
}
